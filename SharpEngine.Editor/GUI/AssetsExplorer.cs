using ImGuiNET;
using SharpEngine.Editor.GUI.PropertiesExtensions;

namespace SharpEngine.Editor.GUI;

public class AssetsExplorer : GuiObject
{
    public static string? CurrentPath { get; set; }

    private string _directionName = "Directory";

    public override void Render()
    {
        ImGui.Begin("Assets Explorer - " + CurrentPath);

        if (ImGui.BeginPopupContextItem("context_asset_menu"))
        {
            BaseProperties.InputText(
                "Directory Name",
                (() => _directionName, (name) => _directionName = name)
            );
            if (ImGui.Button("Create Directory"))
                Directory.CreateDirectory(
                    CurrentPath + Path.DirectorySeparatorChar + _directionName
                );

            ImGui.EndPopup();
        }

        if (CurrentPath != null)
        {
            if (CurrentPath != Editor.ProjectFolder && ImGui.Button(".."))
            {
                CurrentPath = Path.GetRelativePath(
                    ".",
                    Directory.GetParent(CurrentPath)?.FullName
                        ?? Editor.ProjectFolder
                        ?? "."
                );
            }

            foreach (var path in Directory.EnumerateDirectories(CurrentPath))
            {
                var directoryName = Path.GetFileName(path);
                if (ImGui.Button(directoryName))
                    CurrentPath += Path.DirectorySeparatorChar + directoryName;
            }

            foreach (var path in Directory.EnumerateFiles(CurrentPath))
            {
                var fileName = Path.GetFileName(path);
                ImGui.Button(fileName);
            }
        }

        ImGui.End();
    }
}
