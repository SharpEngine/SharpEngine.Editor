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
        if(component is TransformComponent transformComponent)
            transformComponent.DrawProperties();
    }

    public static void DrawProperties(this TransformComponent component)
    {
        if (ImGui.CollapsingHeader("TransformComponent", ImGuiTreeNodeFlags.DefaultOpen))
        {
            BaseProperties.InputVec2("Position", (() => component.Position, x => component.Position = x));
            BaseProperties.InputVec2("Scale", (() => component.Scale, x => component.Scale = x));
            BaseProperties.InputFloat("Rotation", (() => component.Rotation, x => component.Rotation = x));
            BaseProperties.InputInt("ZLayer", (() => component.ZLayer, x => component.ZLayer = x));
        }
    }
}