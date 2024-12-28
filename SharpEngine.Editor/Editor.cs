using System.Text.Json;
using ImGuiNET;
using Raylib_cs;
using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor;

public class Editor: Window
{
    private RenderTexture2D _renderTexture;

    public Editor(): base(1800, 900, "SharpEngine Editor", Core.Utils.Color.Black, null, true, true, true)
    {
        if (!Path.Exists("Projects"))
            Directory.CreateDirectory("Projects");

        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Loading...");
        _renderTexture = Raylib.LoadRenderTexture(900, 600);
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Loaded !");

        AddScene(new Scene());

        Run();

        Unload();
    }

    public void Unload()
    {
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Unloading...");
        Raylib.UnloadRenderTexture(_renderTexture);
        DebugManager.Log(LogLevel.LogInfo, "EDITOR: Unloaded !");
    }
}
