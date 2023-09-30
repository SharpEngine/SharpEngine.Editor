using ImGuiNET;
using Raylib_cs;
using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;
using SharpEngine.Editor.GUI;
using SharpEngine.Editor.Scene;
using Color = Raylib_cs.Color;

namespace SharpEngine.Editor;

public class Editor
{
    public static readonly Core.Scene CurrentScene = new GameScene();
    public static string? ProjectFolder = null;
    public static string ProjectName = "";

    private readonly Window _window;
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
        if (!Path.Exists("Projects"))
            Directory.CreateDirectory("Projects");

        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        _window = new Window(900, 600, "SharpEngine Editor", debug: true, fileLog: true)
        {
            RenderImGui = RenderImGui
        };
        Raylib.MaximizeWindow();
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

        _windowSizeX = 900;
        _windowSizeY = 600;
        _window.AddScene(new EditorScene(this));

        CurrentScene.Window = _window;

        _window.Run();
    }

    public void Load()
    {
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Loading...");
        CurrentScene.Load();
        _renderTexture = Raylib.LoadRenderTexture(900, 600);

        _mainMenuBar = new MainMenuBar();
        _renderWindow = new RenderWindow(_window.SeImGui, _renderTexture);
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

    private void RenderCurrentScene(Window window)
    {
        CurrentScene.Draw();

        Raylib.BeginTextureMode(_renderTexture);
        Raylib.ClearBackground(Color.RED);
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
            {
                foreach (var directory in Directory.GetDirectories("Projects"))
                {
                    ImGui.Button(directory);
                }
                ImGui.Separator();
                ImGui.InputText("Project Name", ref ProjectName, 90);
                ImGui.Button("Create");
                ImGui.End();
            }
        }
    }
}
