// Services/ConsoleLoggerService.cs
public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}
