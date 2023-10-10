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
                ImGui.MenuItem("Save");
                ImGui.Separator();
                if (ImGui.MenuItem("Run"))
                {
                    ProjectBuilder.GenerateProject(
                        Editor.ProjectName,
                        JsonSerializer.Deserialize<ProjectData>(
                            File.ReadAllText($"Projects/{Editor.ProjectName}/project.json")
                        )
                    );
                    ProjectBuilder.RunProject(Editor.ProjectName);
                }

                ImGui.EndMenu();
            }
            ImGui.EndMainMenuBar();
        }
    }
}
