using UnityEditor;

/// <summary>
/// This class enables WebGL building from the command line. Build artifacts are stored in "builds/WebGL" folder. 
///
/// Usage
/// <br />
/// <b>Windows</b>
/// TODO: Test this documentation on Windows. The path may be wrong.
/// <code>
/// set mypath=%cd%
///   @echo % mypath %
///   "C:\Program Files\Unity\Editor\2020.3.3f1\Unity.exe" - quit - batchmode - logFile
///   stdout.log - projectPath % mypath % -executeMethod WebGLBuilder.Build
/// </code>
/// <br />
/// <b>Mac</b>
/// <code>
///   export PROJECT_DIR=`pwd`
///   /Applications/Unity/2020.3.3f1/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $PROJECT_DIR -executeMethod WebGLBuilder.Build -quit -logFile /dev/stdout
/// </code>
/// </summary>
public class WebGLBuilder
{
    private static string buildOutputDir = "builds/WebGL/LoveCubed";

    public static void Build()
    {
        string[] scenes = {
            "Assets/Scenes/MainMenu.unity",
            "Assets/Scenes/StartGameCutScene.unity",
            "Assets/Scenes/Game.unity"
        };

        BuildPipeline.BuildPlayer(scenes, buildOutputDir, BuildTarget.WebGL, BuildOptions.None);
    }
}
