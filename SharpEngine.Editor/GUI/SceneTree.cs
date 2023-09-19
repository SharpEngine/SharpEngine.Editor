using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class SceneTree: GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Screen Tree"))
        {
            if (ImGui.CollapsingHeader("Entities", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var entity in Editor.CurrentScene.Entities)
                    ImGui.Text(entity.Name);
            }

            if (ImGui.CollapsingHeader("Widgets", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var widget in Editor.CurrentScene.Widgets)
                    ImGui.Text(widget.Name);
            }

            ImGui.End();
        }
    }
}