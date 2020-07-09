namespace TwitterAPI.Models.Logging
{
    public class LogManager
    {
        private AbsLog log;

        public LogManager(AbsLog log)
        {
            this.log = log;
        }

        public void MakeLogging() => log.Log();
    }
}
