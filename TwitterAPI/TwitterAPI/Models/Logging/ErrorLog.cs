using System.IO;

namespace TwitterAPI.Models.Logging
{
    public class ErrorLog : AbsLog
    {
        public string CallStack;

        public ErrorLog(string header, string callStack) : base(header)
        {
            this.Type = LogType.Error;
            this.CallStack = callStack;
        }

        public override void Log()
        {
            using (StreamWriter writer = File.AppendText((this.LogFilePath)))
            {
                writer.WriteLine(string.Format(Constants.LogingFormat, this.Date, this.TypeTag, this.Header));

                if (!string.IsNullOrEmpty(this.CallStack))
                    writer.WriteLine(this.CallStack);
            }
        }
    }
}
