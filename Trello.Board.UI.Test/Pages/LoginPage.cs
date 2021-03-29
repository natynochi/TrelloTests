
using OpenQA.Selenium;
using Trello.Board.UI.Test.Context;

namespace Trello.Board.UI.Test.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(TrelloContext driver) : base(driver)
        {
        }

        public void Login()
        {

            var user = Configuration.GetSection("Username").Value;
            var password = Configuration.GetSection("Password").Value;
            
            Driver.WaitFindElement(By.Id("user")).SendKeys(user);
            Driver.WaitFindElement(By.Id("password")).SendKeys(password);
            Driver.WaitFindElement(By.Id("login")).Click();
        }
    }
}