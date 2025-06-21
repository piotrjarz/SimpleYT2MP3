using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.CSPythonScripts
{
    public interface IScriptRunner
    {
        string Run(string scriptPath, params string[] args);
    }
}
