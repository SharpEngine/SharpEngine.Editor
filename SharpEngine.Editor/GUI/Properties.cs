using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class Properties: GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Properties"))
        {
            ImGui.End();
        }
    }
}