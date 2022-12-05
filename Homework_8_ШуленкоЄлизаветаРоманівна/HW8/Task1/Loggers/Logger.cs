namespace Task1.Loggers
{
    public class Logger
    {
        private Action<string> _source;

        public Logger() : this(Console.WriteLine) { }

        public Logger(Action<string> source)
        {
            _source = source;
        }

        public void LogInfo(string text)
        {
            _source($"Info: {text}");
        }
        public void LogWarning(string text)
        {
            _source($"Warning: {text}");
        }
        public void LogError(string text)
        {
            _source($"Error: {text}");
        }
    }
}
