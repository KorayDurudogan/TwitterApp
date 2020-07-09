using System.IO;

namespace TwitterAPI.Models.Logging
{
    public class InfoLog : AbsLog
    {
        public InfoLog(string header) : base(header)
        {
            this.Type = LogType.Info;
        }

        public override void Log()
        {
            using (StreamWriter writer = File.AppendText(this.LogFilePath))
            {
                writer.WriteLine(string.Format(Constants.LogingFormat, this.TypeTag, this.Date, this.Header));
            }
        }
    }
}
