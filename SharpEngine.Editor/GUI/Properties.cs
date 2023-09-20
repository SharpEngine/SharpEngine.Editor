using ImGuiNET;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Widget;

namespace SharpEngine.Editor.GUI;

public class Properties: GuiObject
{
    public static dynamic? Selected { get; set; }

    public override void Render()
    {
        if (ImGui.Begin("Properties"))
        {
            if (Selected is Widget widget)
            {
                ImGui.SetWindowFontScale(1.2f);
                ImGui.Text($"Nom : {widget.Name}");
                ImGui.SetWindowFontScale(1f);
            }
            else if (Selected is Entity entity)
            {
                ImGui.SetWindowFontScale(1.2f);
                ImGui.Text($"Nom : {entity.Name}");
                ImGui.SetWindowFontScale(1f);
                ImGui.Text($"Tag : {entity.Tag}");
            }
            ImGui.End();
        }
    }
}