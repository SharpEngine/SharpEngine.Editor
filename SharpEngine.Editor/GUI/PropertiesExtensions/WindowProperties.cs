using ImGuiNET;
using SharpEngine.Editor.Project.Data;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class WindowProperties
{
    public static void DrawProperties(this ProjectData project)
    {
        ImGui.Text("Window");
        BaseProperties.InputText("Title", (() => project.Title, x => project.Title = x));
        BaseProperties.InputInt(
            "Width",
            (
                () => project.Width,
                x =>
                {
                    project.Width = x;
                    Editor.Instance?.UpdateRenderSize();
                }
            )
        );
        BaseProperties.InputInt(
            "Height",
            (
                () => project.Height,
                x =>
                {
                    project.Height = x;
                    Editor.Instance?.UpdateRenderSize();
                }
            )
        );
        BaseProperties.InputColor(
            "Background Color",
            (() => project.BackgroundColor, x => project.BackgroundColor = x)
        );
    }
}
