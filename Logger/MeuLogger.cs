namespace mvc_test.Loggers;

using Microsoft.Extensions.Logging;

public class MyLogger: ILogger
{

	// Podemos guardar configurações específicas desse logger...
    private string _dbName;

    public MyLogger(string dbName)
    {
        this._dbName = dbName;
    }

    public IDisposable BeginScope<TState>(TState state) => default;

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState,Exception?,string> formatter)
    {
        Console.WriteLine("OH YEAH!");
        Console.WriteLine(formatter(state,null));
    }

}

public sealed class MyLoggerProvider : ILoggerProvider
{

	// Criar Logger com "capeta" como _dbName
	// claro, podemos usar do sistema de configuration para
	// criar um provider que constrói o nosso logger com
	// parâmetros espefícios da aplicação...
    public ILogger CreateLogger(string categoryName) =>
            new MyLogger("capeta");

    public void Dispose()
    {
    }

}
