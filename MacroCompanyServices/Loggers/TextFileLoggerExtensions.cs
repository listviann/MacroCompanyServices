namespace MacroCompanyServices.Loggers
{
    public static class TextFileLoggerExtensions
    {
        public static ILoggingBuilder AddTextFile(this ILoggingBuilder builder, string filepath)
        {
            builder.AddProvider(new TextFileLoggerProvider(filepath));
            return builder;
        }
    }
}
