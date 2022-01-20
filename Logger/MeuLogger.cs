namespace mvc_test.Loggers;

using Microsoft.Extensions.Logging;

//
// Nossa classe customizada de Log
// Ela é inserida na configuração do serviço de MVC
// para ser usada no lugar dos Loggers padrão.
//
public class MyLogger: ILogger
{

	// Podemos guardar configurações específicas desse logger...
    private string _dbName;

    public MyLogger(string dbName)
    {
        this._dbName = dbName;
    }

	// Escopo desse Logger... Ainda não vi os detalhes de como funciona isso,
	// mas podemos simplesmente usar a implementação padrão...
    public IDisposable BeginScope<TState>(TState state) => default;

	// Podemos filtrar se esse log funciona pra determinado LogLevel.
	// Aqui, aceitamos todos os tipos de LogLevel.
    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

	// Método que recebe as requisiçõe de log.
	// Usuário utiliza LogInformation e outros métodos mais específicos ao invéz desse.
	// Daí é roteado para cá com o LogLevel e EventId corretos.
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState,Exception?,string> formatter)
    {
        Console.WriteLine("OH YEAH!"); // escrevendo mensagem qualquer no console
		// 'formatter' é um callback para gerar a string formatada que
		// o usuário informou.
        Console.WriteLine(formatter(state,null));
    }

}

//
// MVC utiliza "Provider" para instanciar a classe de Log.
// Aqui, em CreateLogger, podemos criar nossa instância
// de Log personalizado, usando configurações guardadas, etc.
//
public sealed class MyLoggerProvider : ILoggerProvider
{

	// Criar Logger com "capeta" como _dbName.
    public ILogger CreateLogger(string categoryName) =>
            new MyLogger("capeta");

	// Aparentemente nosso Provider é um Singleton,
	// então se nosso provider guarda recursos
	// que são compartilhados entre as instâncias
	// dos Loggers que ele retorna para o sistema MVC,
	// podemos fazer a limpeza desses recursos aqui.
    public void Dispose()
    {
    }

}
