using ImGuiNET;
using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class EntityProperties
{
    public static void DrawProperties(this Entity entity)
    {
        if (ImGui.CollapsingHeader("Entity", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.Text($"Name : {entity.Name}");
            ImGui.Text($"Tag : {entity.Tag}");
        }

        foreach (var component in entity.Components)
            component.DrawProperties();
    }

    public static void DrawProperties(this Component component)
    {
        switch (component)
        {
            case TransformComponent transformComponent:
                ImGui.Separator();
                transformComponent.DrawProperties();
                break;
            case RectComponent rectComponent:
                ImGui.Separator();
                rectComponent.DrawProperties();
                break;
        }
    }

    public static void DrawProperties(this TransformComponent component)
    {
        if (!ImGui.CollapsingHeader("TransformComponent", ImGuiTreeNodeFlags.DefaultOpen)) return;
        
        BaseProperties.InputVec2("Position", (() => component.Position, x => component.Position = x));
        BaseProperties.InputVec2("Scale", (() => component.Scale, x => component.Scale = x));
        BaseProperties.InputFloat("Rotation", (() => component.Rotation, x => component.Rotation = x));
        BaseProperties.InputInt("ZLayer", (() => component.ZLayer, x => component.ZLayer = x));
    }

    public static void DrawProperties(this RectComponent component)
    {
        if(!ImGui.CollapsingHeader("RectComponent", ImGuiTreeNodeFlags.DefaultOpen)) return;
        
        BaseProperties.InputColor("Color", (() => component.Color, x => component.Color = x));
        BaseProperties.InputVec2("Size", (() => component.Size, x => component.Size = x));
        BaseProperties.InputVec2("Offset", (() => component.Offset, x => component.Offset = x));
        BaseProperties.InputInt("ZLayer Offset", (() => component.ZLayerOffset, x => component.ZLayerOffset = x));
        BaseProperties.InputBool("Displayed", (() => component.Displayed, x => component.Displayed = x));
    }
}