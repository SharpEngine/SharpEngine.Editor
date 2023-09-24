namespace SharpEngine.Editor.Scene;

public class EditorScene : Core.Scene
{
    private readonly Editor _editor;

    public EditorScene(Editor editor)
    {
        _editor = editor;
    }

    public override void Load()
    {
        base.Load();

        _editor.Load();
    }

    public override void Unload()
    {
        base.Unload();

        _editor.Unload();
    }
}
