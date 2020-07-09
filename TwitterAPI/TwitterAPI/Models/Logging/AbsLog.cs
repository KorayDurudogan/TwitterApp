using System;
using System.IO;
using TwitterAPI.Models.Token;

namespace TwitterAPI.Models.Logging
{
    public abstract class AbsLog
    {
        public string Header;

        protected LogType Type;

        protected string LogFilePath;

        protected string Date;

        protected string TypeTag => Type == LogType.Error ? Constants.ErrorTag : Constants.InfoTag;

        public AbsLog(string header)
        {
            this.Header = header;
            this.LogFilePath = Path.GetFullPath(Constants.LogFileName);
            this.Date = string.Format("{0:g}", DateTime.Now);
        }

        public abstract void Log();
    }

    public enum LogType
    {
        Info,
        Error
    }
}
