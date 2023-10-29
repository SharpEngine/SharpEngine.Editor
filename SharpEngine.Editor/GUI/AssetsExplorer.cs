using ImGuiNET;

namespace SharpEngine.Editor.GUI;

public class AssetsExplorer : GuiObject
{
    public static string? CurrentPath;

    private string _directionName = "Directory";

    public override void Render()
    {
        if (ImGui.Begin("Assets Explorer"))
            ImGui.End();
    }
}
