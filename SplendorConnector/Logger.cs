namespace SplendorConnector
{
    #region

    using System;

    #endregion

    public class Logger
    {
        #region Static Fields

        private static Logger logger;

        #endregion

        #region Fields

        private LogType LogLevel;

        #endregion

        #region Constructors and Destructors

        private Logger()
        {
            this.LogLevel = LogType.Debug;
        }

        #endregion

        #region Public Methods and Operators

        public static Logger Instance()
        {
            if (logger == null)
            {
                logger = new Logger();
            }

            return logger;
        }

        public void Debug(string message)
        {
            this.WriteLog(LogType.Debug, message);
        }

        public void Error(string message)
        {
            this.WriteLog(LogType.Error, message);
        }

        public void Message(string message)
        {
            this.WriteLog(LogType.Normal, message);
        }

        public void Warning(string message)
        {
            this.WriteLog(LogType.Warning, message);
        }

        #endregion

        #region Methods

        private string GetTimestamp()
        {
            return string.Format("[{0:G}]", DateTime.Now);
        }

        private void Output(string message)
        {
            Console.WriteLine(message);
        }

        private void WriteLog(LogType logType, string message)
        {
            if (logType > this.LogLevel)
            {
                return;
            }

            const string Template = "{0} {1}: {2}";
            switch (logType)
            {
                case LogType.Error:
                    this.Output(string.Format(Template, "E", this.GetTimestamp(), message));
                    break;
                case LogType.Warning:
                    this.Output(string.Format(Template, "W", this.GetTimestamp(), message));
                    break;
                case LogType.Normal:
                    this.Output(string.Format(Template, " ", this.GetTimestamp(), message));
                    break;
                case LogType.Debug:
                    this.Output(string.Format(Template, "D", this.GetTimestamp(), message));
                    break;
            }
        }

        #endregion
    }

    internal enum LogType
    {
        Error, 

        Warning, 

        Normal, 

        Debug
    }
}