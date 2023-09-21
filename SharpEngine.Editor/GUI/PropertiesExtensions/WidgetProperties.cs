using ImGuiNET;
using SharpEngine.Core.Widget;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class WidgetProperties
{
    public static void DrawProperties(this Widget widget)
    {
        if (ImGui.CollapsingHeader("Widget", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.Text($"Name : {widget.Name}");
            BaseProperties.InputVec2("Position", (() => widget.Position, x => widget.Position = x));
            BaseProperties.InputInt("ZLayer", (() => widget.ZLayer, x => widget.ZLayer = x));
            BaseProperties.InputBool("Displayed", (() => widget.Displayed, x => widget.Displayed = x));
            BaseProperties.InputBool("Active", (() => widget.Active, x => widget.Active = x));
        }
    }

    public static void DrawProperties(this Label label)
    {
        ((Widget)label).DrawProperties();
        if (ImGui.CollapsingHeader("Label", ImGuiTreeNodeFlags.DefaultOpen))
        {
            BaseProperties.InputText("Text", (() => label.Text, x => label.Text = x));
            BaseProperties.InputFont("Font", (() => label.Font, x => label.Font = x));
            BaseProperties.InputColor("Font Color", (() => label.Color, x => label.Color = x));
            BaseProperties.InputInt("Rotation", (() => label.Rotation, x => label.Rotation = x));
            BaseProperties.InputBool("Center Lines", (() => label.CenterAllLines, x => label.CenterAllLines = x));
        }
    }
}