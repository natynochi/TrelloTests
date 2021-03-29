using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Trello.Board.UI.Test.Context
{
    public class TrelloContext : IDisposable
    {
        public IConfiguration Configuration { get; }

        public IWebDriver Driver { get; }

        public TrelloContext()
        {
            Driver = new ChromeDriver();
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public void Init()
        {
            var url = Configuration.GetSection("BaseUrl").Value;
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}