using SharpEngine.Editor.Project.Data.ComponentData;

namespace SharpEngine.Editor.Project.Data;

public class EntityData
{
    public required string Name { get; set; }
    public required string Tag { get; set; }
    public required List<IComponentData> Components { get; set; }
}
