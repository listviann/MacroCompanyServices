namespace MacroCompanyServices.Loggers
{
    public class TextFileLoggerProvider : ILoggerProvider
    {
        private string _filepath;

        public TextFileLoggerProvider(string filepath)
        {
            _filepath = filepath;
        }

        public ILogger CreateLogger(string catecoryName)
        {
            return new TextFileLogger(_filepath);
        }

        public void Dispose() { }
    }
}
