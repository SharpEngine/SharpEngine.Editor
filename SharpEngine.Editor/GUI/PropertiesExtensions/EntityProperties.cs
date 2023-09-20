using ImGuiNET;
using SharpEngine.Core.Entity;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class EntityProperties
{
    public static void DrawProperties(this Entity entity)
    {
        ImGui.SetWindowFontScale(1.2f);
        ImGui.Text($"Nom : {entity.Name}");
        ImGui.SetWindowFontScale(1f);
        ImGui.Text($"Tag : {entity.Tag}");
    }
}