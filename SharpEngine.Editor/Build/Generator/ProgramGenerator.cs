using SharpEngine.Editor.Project.Data;

namespace SharpEngine.Editor.Build.Generator;

public class ProgramGenerator : FileGenerator<ProjectData>
{
    public override string FilePath() => "Program.cs";

    public override string GetCode(ProjectData data) =>
        $$"""
          using SharpEngine.Core;
          using SharpEngine.Core.Utils;

          namespace {{data.Title.Replace(" ", ".")}};

          internal static class Program
          {
              private static void Main()
              {
                  var window = new Window({{data.Width}}, {{data.Height}}, "{{data.Title}}", {{Generators.ColorConstructor.GetCode(data.BackgroundColor)}});
          
                  window.AddScene(new Scene());
          
                  window.Run();
              }
          }
          """;
}
