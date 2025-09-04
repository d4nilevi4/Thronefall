using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ThronefallEditor
{
    public class CodeGeneratorTool : EditorWindow
    {
        [MenuItem("Tools/GenerateCode")]
        public static void RunCodeGenerator()
        {
            string solutionDir = GetSolutionDirectory();
            
            string batRelativePath = Path.Combine(solutionDir, @"..\..\Jenny\Jenny-Gen.bat");
            string batFullPath = Path.GetFullPath(batRelativePath);

            if (File.Exists(batFullPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = batFullPath,
                    WorkingDirectory = Path.GetDirectoryName(batFullPath) ?? string.Empty,
                    CreateNoWindow = false,
                    UseShellExecute = true
                };

                Process process = new Process { StartInfo = startInfo };
                process.Start();
                UnityEngine.Debug.Log("Codegen process started: " + batFullPath);
            }
            else
            {
                UnityEngine.Debug.LogError("File not found: " + batFullPath);
            }
        }

        private static string GetSolutionDirectory()
        {
            return Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        }
    }
}