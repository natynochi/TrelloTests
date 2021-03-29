using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Trello.Board.UI.Test.Context;

namespace Trello.Board.UI.Test.Pages
{
    public abstract class BasePage
    {
        protected BasePage(TrelloContext context)
        {
            Driver = context.Driver;
            Configuration = context.Configuration;
        }

        protected IWebDriver Driver { get; }
        protected IConfiguration Configuration { get; }
    }
}