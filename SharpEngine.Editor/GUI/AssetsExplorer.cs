using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class AssetsExplorer : GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Assets Explorer"))
            ImGui.End();
    }
}
