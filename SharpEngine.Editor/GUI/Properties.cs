using ImGuiNET;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Widget;
using SharpEngine.Editor.GUI.PropertiesExtensions;

namespace SharpEngine.Editor.GUI;

public class Properties: GuiObject
{
    public static dynamic? Selected { get; set; }

    public override void Render()
    {
        if (ImGui.Begin("Properties"))
        {
            switch (Selected)
            {
                case Entity entity:
                    entity.AddComponentProperties();
                    ImGui.Separator();
                    entity.DrawProperties();
                    break;
                case Label label:
                    label.DrawProperties();
                    break;
                case Widget widget:
                    widget.DrawProperties();
                    break;
            }

            ImGui.End();
        }
    }
}