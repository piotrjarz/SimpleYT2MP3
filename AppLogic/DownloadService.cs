using SimpleYT2MP3.AppLogic.Interfaces;
using SimpleYT2MP3.CSPythonScripts;
using SimpleYT2MP3.CSPythonScripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.AppLogic
{
    class DownloadService : IDownloadService
    {
        private readonly IDownloadStatusProvider _statusProvider;
        private readonly IScriptPathProvider _scriptPathProvider;
        private readonly IScriptRunner _scriptRunner;

        public DownloadService(IDownloadStatusProvider statusProvider, IScriptPathProvider scriptPathProvider, IScriptRunner scriptRunner)
        {
            _statusProvider = statusProvider;
            _scriptPathProvider = scriptPathProvider;
            _scriptRunner = scriptRunner;
        }

        public async Task<string> RunDownloadAsync(string link, string outputDirectory)
        {
            string scriptPath = _scriptPathProvider.GetScriptPath("Download");
            return await Task.Run(() => _scriptRunner.Run(scriptPath, link, outputDirectory));
        }
    }
}
