using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;

namespace SharpEngine.Editor.Scene;

public class GameScene: Core.Scene
{
    public GameScene()
    {
        var e = new Entity
        {
            Name = "Red Rect"
        };
        e.AddComponent(new TransformComponent(new Vec2(60)));
        e.AddComponent(new RectComponent(Color.Cyan, new Vec2(50)));
        AddEntity(e);

        AddWidget(new Label(new Vec2(300), "Heyo", "RAYLIB_DEFAULT", color: Color.Black, fontSize: 30, zLayer: 30)).Name = "Title";
    }
}