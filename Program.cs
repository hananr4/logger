using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class Program
{
  static void Main()
  {
    using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
      builder.AddConsole();
      //    builder.AddJsonConsole();
    });
    ILogger logger = loggerFactory.CreateLogger<Program>();
    logger.LogWarning("Casi ocurrio un error");
    logger.LogError("Aqui ocurrio un error");


    try
    {
      logger.LogInformation("Starting up");
      new AppService(logger).Run();
    }
    catch (Exception ex)
    {
      logger.LogCritical(ex, "Application start-up failed");
      throw;
    }


    logger.LogInformation("Starting up");

  }
}



public class AppService
{
  private readonly ILogger _logger;
  public AppService(ILogger logger)
  {
    _logger = logger;
  }

  public void Run()
  {
    var a = 0;
    var b = 4 / a;
    _logger.LogInformation("Running");
  }
}


