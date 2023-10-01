using SharpEngine.Editor.Project.Data;

namespace SharpEngine.Editor.Build.Generator;

public class ProgramGenerator : FileGenerator<ProjectData>
{
    protected override string FilePath() => "Program.cs";

    protected override string GetCode(ProjectData data) =>
        $$"""
          using SharpEngine.Core;

          namespace BasicWindow;

          internal static class Program
          {
              private static void Main()
              {
                  var window = new Window({{data.Width}}, {{data.Height}}, "{{data.Title}}");
          
                  window.AddScene(new Scene());
          
                  window.Run();
              }
          }
          """;
}
