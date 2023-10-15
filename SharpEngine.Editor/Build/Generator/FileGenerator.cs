namespace SharpEngine.Editor.Build.Generator;

public abstract class FileGenerator<T>
{
    public void Generate(T data)
    {
        File.WriteAllText(FilePath(), GetCode(data));
    }

    public abstract string FilePath();
    public abstract string GetCode(T data);
}
