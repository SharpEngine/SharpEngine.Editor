using ImGuiNET;
using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class EntityProperties
{
    private static string _component = "Transform";
    private static readonly List<Component> RemovedComponents = new();

    public static void AddComponentProperties(this Entity entity)
    {
        ImGui.Columns(2);
        if (ImGui.BeginCombo("Component", _component))
        {
            foreach (var component in new[] { "Transform", "Rect" })
                if (ImGui.Selectable(component, _component == component))
                    _component = component;
            ImGui.EndCombo();
        }

        ImGui.NextColumn();
        if (ImGui.Button("Add Component"))
        {
            switch (_component)
            {
                case "Transform":
                    entity.AddComponent(new TransformComponent()).Load();
                    break;
                case "Rect":
                    entity.AddComponent(new RectComponent(Color.Black, new Vec2(10))).Load();
                    break;
            }
        }

        ImGui.Columns(1);
    }

    public static void DrawProperties(this Entity entity)
    {
        if (ImGui.CollapsingHeader("Entity", ImGuiTreeNodeFlags.DefaultOpen))
        {
            ImGui.Text($"Name : {entity.Name}");
            ImGui.Text($"Tag : {entity.Tag}");
        }

        RemovedComponents.Clear();
        var i = 0;
        foreach (var component in entity.Components)
            component.DrawProperties(i++);

        foreach (var component in RemovedComponents)
        {
            component.Unload();
            entity.RemoveComponent(component);
        }
    }

    public static void DrawProperties(this Component component, int index)
    {
        ImGui.PushID(index);
        switch (component)
        {
            case TransformComponent transformComponent:
                transformComponent.DrawComponentProperties(transformComponent.DrawProperties);
                break;
            case RectComponent rectComponent:
                rectComponent.DrawComponentProperties(rectComponent.DrawProperties);
                break;
        }
        ImGui.PopID();
    }

    public static void DrawComponentProperties(this Component component, Action drawProperties)
    {
        ImGui.Separator();
        drawProperties();
        if (ImGui.Button("Delete Component"))
            RemovedComponents.Add(component);
    }

    public static void DrawProperties(this TransformComponent component)
    {
        if (!ImGui.CollapsingHeader($"Transform", ImGuiTreeNodeFlags.DefaultOpen))
            return;

        BaseProperties.InputVec2(
            "Position",
            (() => component.Position, x => component.Position = x)
        );
        BaseProperties.InputVec2("Scale", (() => component.Scale, x => component.Scale = x));
        BaseProperties.InputFloat(
            "Rotation",
            (() => component.Rotation, x => component.Rotation = x)
        );
        BaseProperties.InputInt("ZLayer", (() => component.ZLayer, x => component.ZLayer = x));
    }

    public static void DrawProperties(this RectComponent component)
    {
        if (!ImGui.CollapsingHeader($"Rect", ImGuiTreeNodeFlags.DefaultOpen))
            return;

        BaseProperties.InputColor("Color", (() => component.Color, x => component.Color = x));
        BaseProperties.InputVec2("Size", (() => component.Size, x => component.Size = x));
        BaseProperties.InputVec2("Offset", (() => component.Offset, x => component.Offset = x));
        BaseProperties.InputInt(
            "ZLayer Offset",
            (() => component.ZLayerOffset, x => component.ZLayerOffset = x)
        );
        BaseProperties.InputBool(
            "Displayed",
            (() => component.Displayed, x => component.Displayed = x)
        );
    }
}
