namespace Library;

public enum LogSeverityEnum { Info, Warning, Error }

public interface ILogSink
{
    void Write(string message);
}

public class FileLog : ILogSink
{
    public void Write(string message)
    {
        //Write in the file
    }
}

public class ConsoleLog : ILogSink
{
    public void Write(string message)
    {
        Console.Write(message);
    }

}
public class LogLibrary
{
    private readonly List<ILogSink> _logSinks;
    private readonly LogSeverityEnum _minimumSeverity;

    public LogLibrary(List<ILogSink> logSinks, LogSeverityEnum minimumSeverity)
    {
        if (logSinks == null || logSinks.Count == 0) throw new Exception("You need to inform at least one sink");

        _logSinks = logSinks;
        _minimumSeverity = minimumSeverity;
    }

    public void Log(string message, LogSeverityEnum severity)
    {
        if(_minimumSeverity > severity) return;

        string logMessage = string.Format("TimeStamp: {0}, Message: {1}, LogSeverity: {2}", DateTime.UtcNow, message, severity);

        foreach(var sink in _logSinks)
        {
            sink.Write(logMessage);
        }
    }
}