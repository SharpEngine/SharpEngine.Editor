using System.Diagnostics;
using SharpEngine.Editor.Build.Generator;
using SharpEngine.Editor.Project.Data;

namespace SharpEngine.Editor.Build;

public static class ProjectBuilder
{
    public static void GenerateProject(string projectName, ProjectData projectData)
    {
        Directory.SetCurrentDirectory($"Build/{projectName}");
        new ProgramGenerator().Generate(projectData);
        Directory.SetCurrentDirectory("../..");
    }

    public static void RunProject(string projectName)
    {
        Directory.SetCurrentDirectory($"Build/{projectName}");
        new Process
        {
            StartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C dotnet run"
            }
        }.Start();
        Directory.SetCurrentDirectory("../..");
    }

    public static void CreateSolution(string projectName)
    {
        var solutionName = projectName.Replace(" ", "_");
        if (!Directory.Exists("Build"))
            Directory.CreateDirectory("Build");

        Directory.SetCurrentDirectory("Build");

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C dotnet new console -n {solutionName}"
            }
        };
        process.Start();

        Directory.SetCurrentDirectory("..");
    }
}
