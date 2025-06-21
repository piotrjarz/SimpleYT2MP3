using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimpleYT2MP3.CSPythonScripts
{
    public class PythonScriptsRunner : IScriptRunner
    {
        private readonly string _pythonExecutable;

        public PythonScriptsRunner (string pythonExecutable = "python")
        {
            _pythonExecutable = pythonExecutable;
        }

        public string Run(string scriptPath, params string[] args)
        {
            string output = String.Empty;
            try
            {
                string arguments = $"\"{scriptPath}\" {string.Join(" ", args.Select(a => $"\"{a}\""))}";

                var psi = new ProcessStartInfo
                {
                    FileName = _pythonExecutable,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();

                    output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    return string.IsNullOrEmpty(errors) ? output : $"Error: {errors}";

                }
            }
            catch(Exception ex)
            {
                return $"Error: ${ex}";
            }
        }
    }
}
