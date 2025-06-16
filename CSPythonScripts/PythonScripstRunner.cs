using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimpleYT2MP3.CSPythonScripts
{
    public class PythonScripstRunner
    {
        public static string RunScript(string scriptPath, string input, string downloadDirectory = "")
        {
            string output = String.Empty;
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "python";
                psi.Arguments = $"\"{scriptPath}\" \"{input}\" \"{downloadDirectory}\"";
                psi.RedirectStandardError = true;
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();

                    output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(errors))
                    {
                        return $"Błąd: {errors}";
                    }
                    return output;

                }
            }
            catch(Exception ex)
            {
                return $"Błąd: ${ex}";
            }
        }
    }
}
