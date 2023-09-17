using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.Scene;

public class GameScene: Core.Scene
{
    public GameScene()
    {
        var e = new Entity();
        e.AddComponent(new TransformComponent(new Vec2(60)));
        e.AddComponent(new RectComponent(Color.Cyan, new Vec2(50)));
        AddEntity(e);
    }
}