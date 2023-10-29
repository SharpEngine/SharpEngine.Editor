using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class AssetsExplorer : GuiObject
{
    public static string? CurrentPath;

    private string _directionName = "Directory";

    public override void Render()
    {
        if (ImGui.Begin("Assets Explorer"))
        {
            if (ImGui.BeginPopupContextItem("context_asset_menu"))
            {
                BaseProperties.InputText(
                    "Directory Name",
                    (() => _directionName, (name) => _directionName = name)
                );
                if (ImGui.Button("Create Directory"))
                    Directory.CreateDirectory(CurrentPath + "/" + _directionName);

                ImGui.EndPopup();
            }

            if (CurrentPath != null)
            {
                foreach (var path in Directory.EnumerateDirectories(CurrentPath))
                    ImGui.Button("D-" + path);

                foreach (var path in Directory.EnumerateFiles(CurrentPath))
                    ImGui.Button("F-" + path);
            }

            ImGui.End();
        }
    }
}
