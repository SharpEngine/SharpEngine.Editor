using ImGuiNET;
using Raylib_cs;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.GUI;

public class RenderWindow : GuiObject
{
    private readonly SeImGui _seImGui;
    private readonly RenderTexture2D _renderTexture;

    public RenderWindow(SeImGui seImGui, RenderTexture2D renderTexture)
    {
        _seImGui = seImGui;
        _renderTexture = renderTexture;
    }

    public override void Render()
    {
        if (ImGui.Begin("Render"))
        {
            _seImGui.ImageRenderTexture(_renderTexture);

            ImGui.End();
        }
    }
}
