using System.Diagnostics;

namespace SharpEngine.Editor.Build;

public static class ProjectBuilder
{
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
