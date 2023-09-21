using System.Numerics;
using ImGuiNET;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.GUI.PropertiesExtensions;

public static class BaseProperties
{
    public static void InputFont(string label, (Func<string> get, Action<string> set) outValue)
    {
        var value = outValue.get();
        if (ImGui.BeginCombo(label, value))
        {
            if (ImGui.Selectable("RAYLIB_DEFAULT"))
                value = "RAYLIB_DEFAULT";
            ImGui.EndCombo();
        }
        outValue.set(value);
    }
    
    public static void InputVec2(string label, (Func<Vec2> get, Action<Vec2> set) outValue)
    {
        Vector2 value = outValue.get();
        ImGui.InputFloat2(label, ref value);
        outValue.set(value);
    }
    
    public static void InputColor(string label, (Func<Color> get, Action<Color> set) outValue)
    {
        var value = outValue.get().ToVec4();
        ImGui.ColorEdit4(label, ref value);
        outValue.set(Color.FromVec4(value));
    }
    
    public static void InputFloat(string label, (Func<float> get, Action<float> set) outValue)
    {
        var value = outValue.get();
        ImGui.InputFloat(label, ref value, 1);
        outValue.set(value);
    }
    
    public static void InputInt(string label, (Func<int> get, Action<int> set) outValue)
    {
        var value = outValue.get();
        ImGui.InputInt(label, ref value, 1);
        outValue.set(value);
    }
    
    public static void InputBool(string label, (Func<bool> get, Action<bool> set) outValue)
    {
        var value = outValue.get();
        ImGui.Checkbox(label, ref value);
        outValue.set(value);
    }
    
    public static void InputText(string label, (Func<string> get, Action<string> set) outValue)
    {
        var value = outValue.get();
        ImGui.InputText(label, ref value, 40000 );
        outValue.set(value);
    }
    
    public static void InputMultilineText(string label, (Func<string> get, Action<string> set) outValue)
    {
        var value = outValue.get();
        ImGui.InputTextMultiline(label, ref value, 999999, new Vector2(ImGui.GetContentRegionAvail().X, 200));
        outValue.set(value);
    }
}