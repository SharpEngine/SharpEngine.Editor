using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class Objects: GuiObject
{
    public override void Render()
    {
        if (ImGui.Begin("Objects"))
        {
            if (ImGui.CollapsingHeader("Entities", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var entity in Editor.CurrentScene.Entities)
                    if (ImGui.Selectable(entity.Name))
                        Properties.Selected = entity;
            }

            if (ImGui.CollapsingHeader("Widgets", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var widget in Editor.CurrentScene.Widgets)
                    if (ImGui.Selectable(widget.Name))
                        Properties.Selected = widget;
            }

            if (ImGui.CollapsingHeader("Others", ImGuiTreeNodeFlags.DefaultOpen))
            {
                ImGui.Selectable("Camera");
                ImGui.Selectable("Scene");
                ImGui.Selectable("Window");
            }

            ImGui.End();
        }
    }
}