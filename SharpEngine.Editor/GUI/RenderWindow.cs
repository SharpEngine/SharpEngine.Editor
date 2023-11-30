using ImGuiNET;
using Raylib_cs;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.GUI;

public class RenderWindow : GuiObject
{
    private readonly RenderTexture2D _renderTexture;

    public RenderWindow(RenderTexture2D renderTexture)
    {
        _renderTexture = renderTexture;
    }

    public override void Render()
    {
        if (ImGui.Begin("Render"))
        {
            SeImGui.ImageRenderTexture(_renderTexture);

            ImGui.End();
        }
    }
}
