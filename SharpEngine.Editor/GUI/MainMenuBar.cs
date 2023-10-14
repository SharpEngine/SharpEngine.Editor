using System.Text.Json;
using ImGuiNET;
using SharpEngine.Editor.Build;
using SharpEngine.Editor.Project.Data;

namespace SharpEngine.Editor.GUI;

public class MainMenuBar : GuiObject
{
    public override void Render()
    {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("Project"))
            {
                if (ImGui.MenuItem("Save Project"))
                {
                    File.WriteAllText(
                        $"Projects/{Editor.ProjectName}/project.json",
                        JsonSerializer.Serialize(Editor.ProjectData)
                    );
                }
                ImGui.Separator();
                if (ImGui.MenuItem("Run Project"))
                {
                    ProjectBuilder.GenerateProject(Editor.ProjectName, Editor.ProjectData);
                    ProjectBuilder.RunProject(Editor.ProjectName);
                }

                ImGui.EndMenu();
            }
            ImGui.EndMainMenuBar();
        }
    }
}
