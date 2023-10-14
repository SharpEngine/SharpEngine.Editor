using SharpEngine.Core.Math;

namespace SharpEngine.Editor.Project.Data.ComponentData;

public class TransformData : IComponentData
{
    public Vec2 Position { get; set; }
    public Vec2 Scale { get; set; }
    public float Rotation { get; set; }
    public int ZLayer { get; set; }
}
