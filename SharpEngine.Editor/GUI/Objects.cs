using ImGuiNET;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;

namespace SharpEngine.Editor.GUI;

public class Objects : GuiObject
{
    private static string _widget = "Label";
    private static string _widgetName = "";
    private static string _entityName = "";

    public override void Render()
    {
        if (ImGui.Begin("Objects"))
        {
            if (ImGui.CollapsingHeader("Entities", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var entity in Editor.CurrentScene.Entities)
                    if (ImGui.Selectable(entity.Name))
                        Properties.Selected = entity;

                ImGui.Separator();
                RenderAddEntity();
            }

            if (ImGui.CollapsingHeader("Widgets", ImGuiTreeNodeFlags.DefaultOpen))
            {
                foreach (var widget in Editor.CurrentScene.Widgets)
                    if (ImGui.Selectable(widget.Name))
                        Properties.Selected = widget;

                ImGui.Separator();
                RenderAddWidget();
            }

            ImGui.End();
        }
    }

    public void RenderAddEntity()
    {
        ImGui.Columns(2);
        ImGui.InputText("Entity Name", ref _entityName, 90);

        ImGui.NextColumn();
        if (ImGui.Button("Add Entity"))
        {
            var entity = Editor.CurrentScene.AddEntity(new Entity());
            entity.Name = _entityName;
            entity.Load();
        }

        ImGui.Columns(1);
    }

    public void RenderAddWidget()
    {
        ImGui.InputText("Widget Name", ref _widgetName, 90);
        ImGui.Columns(2);
        if (ImGui.BeginCombo("Widget", _widget))
        {
            foreach (var widget in new[] { "Label", "ColorRect" })
                if (ImGui.Selectable(widget, _widget == widget))
                    _widget = widget;
            ImGui.EndCombo();
        }

        ImGui.NextColumn();
        if (ImGui.Button("Add Widget"))
        {
            Widget widget = _widget switch
            {
                "ColorRect" => Editor.CurrentScene.AddWidget(new ColorRect(Vec2.Zero)),
                _ => Editor.CurrentScene.AddWidget(new Label(Vec2.Zero, "", "RAYLIB_DEFAULT"))
            };
            widget.Name = _widgetName;
            widget.Load();
        }

        ImGui.Columns(1);
    }
}
