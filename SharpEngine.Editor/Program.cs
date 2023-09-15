using SharpEngine.Core;
using SharpEngine.Editor.Scene;

var window = new Window(900, 600, "SharpEngine Editor", debug: true, fileLog: true);

window.AddScene(new TempScene());

window.Run();