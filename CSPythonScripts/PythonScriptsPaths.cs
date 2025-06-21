using SimpleYT2MP3.CSPythonScripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.CSPythonScripts
{
    public class DictionaryScriptPathsProvider : IScriptPathProvider
    {
        private readonly Dictionary<string, string> _scriptPaths;

        public DictionaryScriptPathsProvider()
        {
            _scriptPaths = new Dictionary<string, string>
            {
                {"Download", "python\\YoutubeDownloadScript.py" }
            };
        }

        public string GetScriptPath(string scriptKey)
        {
            if(_scriptPaths.TryGetValue(scriptKey, out string path))
            {
                return path;
            }
            throw new KeyNotFoundException($"Script key '{scriptKey}' not found!");
        }
    }
}
