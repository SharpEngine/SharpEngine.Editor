using SharpEngine.Editor.Project.Data.ComponentData;

namespace SharpEngine.Editor.Project.Data;

public class EntityData
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public List<IComponentData> Components { get; set; }
}
