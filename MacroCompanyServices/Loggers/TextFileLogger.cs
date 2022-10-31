namespace MacroCompanyServices.Loggers
{
    public class TextFileLogger : ILogger, IDisposable
    {
        private string _filepath;
        private static object _lock = new object();

        public TextFileLogger(string filepath)
        {
            _filepath = filepath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                File.AppendAllText(_filepath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}
