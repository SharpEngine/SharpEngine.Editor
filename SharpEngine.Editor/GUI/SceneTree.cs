using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class SceneTree: GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Screen Tree"))
        {
            foreach (var entity in Editor.CurrentScene.Entities)
                ImGui.Text(entity.Tag);
            
            ImGui.Separator();
            
            foreach (var widget in Editor.CurrentScene.Widgets)
                ImGui.Text(widget.Position.ToString());
            
            ImGui.End();
        }
    }
}