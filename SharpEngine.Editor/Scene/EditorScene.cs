namespace SharpEngine.Editor.Scene;

public class EditorScene(Editor editor) : Core.Scene
{
    private readonly Editor _editor = editor;

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
