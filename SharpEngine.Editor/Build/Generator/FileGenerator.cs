namespace SharpEngine.Editor.Build.Generator;

public abstract class FileGenerator<T>
{
    public void Generate(T data)
    {
        File.WriteAllText(FilePath(), GetCode(data));
    }

    protected abstract string FilePath();
    protected abstract string GetCode(T data);
}
