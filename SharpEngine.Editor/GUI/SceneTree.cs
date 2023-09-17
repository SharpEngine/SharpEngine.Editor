using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class SceneTree: GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Screen Tree"))
        {
            ImGui.End();
        }
    }
}