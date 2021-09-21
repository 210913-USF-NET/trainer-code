using System;
using Serilog;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // using(var logger = new LoggerConfiguration()
            // .MinimumLevel.Debug()
            // .WriteTo.Console()
            // .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
            // .CreateLogger()){
            //     //I have access to my logger in this block
            //     //but once I exit,
            //     //my logger is disposed
            // }
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Application Starting...");
            
            new MainMenu().Start();

            Log.Information("Application closing...");
            Log.CloseAndFlush();
        }
    }
}
