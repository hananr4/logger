using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class Program
{
  static void Main()
  {
    var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
    
    using ILoggerFactory loggerFactory = LoggerFactory.Create(
      builder =>
    {
      builder.AddConsole();
      builder.AddEventLog();
      
      builder.AddConfiguration(
        config.GetSection("Logging")
      );
      //  builder.AddJsonConsole();
    });

    


    ILogger logger = loggerFactory.CreateLogger<Program>();
    logger.LogWarning("Casi ocurrio un error");
    logger.LogError("Aqui ocurrio un error");


    try
    {
      logger.LogInformation("Starting up");
      var app = new AppService(logger, config);
      app.Run();
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
  private readonly IConfiguration _config;
  public AppService(ILogger logger, IConfiguration config)
  {
    _logger = logger;
    _config = config;
  }

  public void Run()
  {

    
    var ruc = _config.GetValue<string>("Sri:Ruc");

    _logger.LogInformation($"Ruc: {ruc}");

    var a = 0;
    var b = 4 / a;
    _logger.LogInformation("Running");
  }
}


