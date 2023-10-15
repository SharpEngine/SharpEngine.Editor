using SharpEngine.Core.Utils;

namespace SharpEngine.Editor.Build.Generator;

public class ColorConstructorGenerator : FileGenerator<Color>
{
    public override string FilePath()
    {
        throw new NotImplementedException();
    }

    public override string GetCode(Color data) =>
        $"new Color({data.R}, {data.G}, {data.B}, {data.A})";
}
