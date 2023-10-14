using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.Project.Data;

public class ProjectData
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Title { get; set; }
    public Color BackgroundColor { get; set; }
    public int CurrentScene { get; set; }
    public List<string> Scenes { get; set; }
}
