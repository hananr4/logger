using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class Program
{
  static void Main()
  {
    using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    ILogger logger = loggerFactory.CreateLogger<Program>();
    logger.LogInformation("Mensaje informativo {0}", Directory.GetCurrentDirectory());
    logger.LogWarning("Casi ocurrio un error");
    logger.LogError("Aqui ocurrio un error");
  }
}