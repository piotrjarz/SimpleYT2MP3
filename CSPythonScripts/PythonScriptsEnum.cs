using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleYT2MP3.CSPythonScripts
{
    public enum EDownloadState
    {
        IDLE,
        START,
        PROCESSING,
        FINISHED,
        ERROR,
        BAD_GATEWAY_ERROR
    }

    public class PythonScriptsEnum
    {
        private static EDownloadState CurrentDownloadState = EDownloadState.IDLE;

        public static EDownloadState GetCurrentDownloadState()
        {
            return CurrentDownloadState; 
        }

        public static void SetCurrentDownloadState(EDownloadState state)
        {
            try
            {
                CurrentDownloadState = state;
            }
            catch 
            {
                CurrentDownloadState = EDownloadState.IDLE;
            }
        }

    }
}
