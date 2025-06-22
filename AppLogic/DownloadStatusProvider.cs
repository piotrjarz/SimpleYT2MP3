using SimpleYT2MP3.CSPythonScripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.AppLogic
{
    class DownloadStatusContentProvider: IDownloadStatusProvider
    {
        private readonly Dictionary<string, string> _statuses;
        public DownloadStatusContentProvider() 
        {
            _statuses = new Dictionary<string, string>
            {
                { "Download",   "Downloading..." },
                { "Success",    $"Finished downloading succesfully!" },
                { "Error",      $"Error has occured"},
                { "Empty",      ""}    

            };
        }

        public string GetDownloadStatus(string statusKey)
        {
            if (_statuses.TryGetValue(statusKey, out string status))
            {
                return status;
            }
            throw new KeyNotFoundException($"Status key '{status}' not found!");
        }
    }
}
