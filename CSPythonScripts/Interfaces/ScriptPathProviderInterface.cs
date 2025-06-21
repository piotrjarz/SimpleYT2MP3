using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.CSPythonScripts.Interfaces
{
    public interface IScriptPathProvider
    {
        string GetScriptPath(string scriptKey);
    }
}
