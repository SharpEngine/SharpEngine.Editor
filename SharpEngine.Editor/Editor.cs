using System.Text.Json;
using ImGuiNET;
using Raylib_cs;
using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;
using SharpEngine.Editor.Build;
using SharpEngine.Editor.GUI;
using SharpEngine.Editor.Project.Data;
using SharpEngine.Editor.Scene;

namespace SharpEngine.Editor;

public class Editor
{
    internal static Editor? Instance { get; private set; }

    internal static readonly Core.Scene CurrentScene = new GameScene();
    internal static string? ProjectFolder { get; set; } = null;
    internal static string ProjectName { get; set; } = "";
    internal static ProjectData ProjectData { get; set; } = new()
    {
        Title = "",
        Scenes = []
    };

    private static bool _exists { get; set; } = false;
    private RenderTexture2D _renderTexture;

    private int _windowSizeX;
    private int _windowSizeY;

    private MainMenuBar? _mainMenuBar;
    private RenderWindow? _renderWindow;
    private Properties? _properties;
    private Objects? _sceneTree;
    private AssetsExplorer? _assetsExplorer;

    public Editor()
    {
        Instance = this;

        if (!Path.Exists("Projects"))
            Directory.CreateDirectory("Projects");

        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        var window = new Window(900, 600, "SharpEngine Editor", debug: true, fileLog: true)
        {
            RenderImGui = RenderImGui
        };
        Raylib.MaximizeWindow();
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

        _windowSizeX = 900;
        _windowSizeY = 600;
        window.AddScene(new EditorScene(this));

        CurrentScene.Window = window;

        window.Run();
    }

    public void Load()
    {
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Loading...");
        CurrentScene.Load();
        _renderTexture = Raylib.LoadRenderTexture(900, 600);

        _mainMenuBar = new MainMenuBar();
        _renderWindow = new RenderWindow(_renderTexture);
        _properties = new Properties();
        _sceneTree = new Objects();
        _assetsExplorer = new AssetsExplorer();
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Loaded !");
    }

    public void Unload()
    {
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Unloading...");
        Raylib.UnloadRenderTexture(_renderTexture);
        CurrentScene.Unload();
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Unloaded !");
    }

    public void UpdateRenderSize()
    {
        _renderTexture.Texture.Width = ProjectData.Width;
        _renderTexture.Texture.Height = ProjectData.Height;
    }

    private void RenderCurrentScene(Window window)
    {
        CurrentScene.Draw();

        Raylib.BeginTextureMode(_renderTexture);
        Raylib.ClearBackground(ProjectData.BackgroundColor);
        SERender.Draw(window);
        Raylib.EndTextureMode();
    }

    private void RenderImGui(Window window)
    {
        // Resize if necessary
        if (Raylib.GetScreenWidth() != _windowSizeX || Raylib.GetScreenHeight() != _windowSizeY)
        {
            _windowSizeX = Raylib.GetScreenWidth();
            _windowSizeY = Raylib.GetScreenHeight();
            window.SeImGui.Resize(_windowSizeX, _windowSizeY);
        }

        // Render Current Scene
        RenderCurrentScene(window);

        // Create ImGui
        if (ProjectFolder != null)
        {
            _mainMenuBar?.Render();

            ImGui.DockSpaceOverViewport(
                ImGui.GetMainViewport(),
                ImGuiDockNodeFlags.PassthruCentralNode
            );
            _renderWindow?.Render();
            _sceneTree?.Render();
            _assetsExplorer?.Render();
            _properties?.Render();
        }
        else
        {
            var io = ImGui.GetIO();
            ImGui.SetNextWindowSize(new Vec2(io.DisplaySize.X / 2f, io.DisplaySize.Y / 2f));
            ImGui.SetWindowPos(new Vec2(io.DisplaySize.X / 2f, io.DisplaySize.Y / 2f));

            if (
                ImGui.Begin(
                    "Projects List",
                    ImGuiWindowFlags.NoMove
                        | ImGuiWindowFlags.NoResize
                        | ImGuiWindowFlags.NoCollapse
                )
            )
                RenderProjectsList();
        }
    }

    private void RenderProjectsList()
    {
        foreach (var directory in Directory.GetDirectories("Projects").Where(x => ImGui.Button(Path.GetFileName(x))))
        {
            ProjectName = Path.GetFileName(directory);
            ProjectFolder = directory;
            AssetsExplorer.CurrentPath = ProjectFolder;
            ProjectData = JsonSerializer.Deserialize<ProjectData>(
                File.ReadAllText($"Projects/{ProjectName}/project.json")
            ) ?? throw new JsonException("Cannot deserialize project");
            UpdateRenderSize();
        }
        ImGui.Separator();
        if (_exists)
            ImGui.TextColored(Core.Utils.Color.Red.ToVec4(), "Project already exists !");

        var project = ProjectName;
        ImGui.InputText("Project Name", ref project, 90);
        ProjectName = project;

        if (ImGui.Button("Create"))
        {
            if (Directory.Exists($"Projects/{ProjectName}"))
                _exists = true;
            else
            {
                ProjectData = new ProjectData
                {
                    Width = 900,
                    Height = 600,
                    Title = ProjectName,
                    BackgroundColor = Core.Utils.Color.Black,
                    CurrentScene = 0,
                    Scenes = []
                };
                Directory.CreateDirectory($"Projects/{ProjectName}");
                File.WriteAllText(
                    $"Projects/{ProjectName}/project.json",
                    JsonSerializer.Serialize(ProjectData)
                );
                ProjectBuilder.CreateSolution(ProjectName);
                ProjectFolder = $"Projects/{ProjectName}";
                AssetsExplorer.CurrentPath = ProjectFolder;
            }
        }
        ImGui.End();
    }
}
