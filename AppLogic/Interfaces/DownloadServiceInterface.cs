using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.AppLogic.Interfaces
{
    public interface IDownloadService
    {
        Task<string> RunDownloadAsync(string link, string outputDirectory);
    }
}
