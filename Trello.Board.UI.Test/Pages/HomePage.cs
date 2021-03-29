using OpenQA.Selenium;
using Trello.Board.UI.Test.Context;

namespace Trello.Board.UI.Test.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(TrelloContext driver) : base(driver)
        {
        }
        
        public void CreateBoard(string boardName, string permission, string color)
        {
            IWebElement btnCreateNewBoard = Driver.WaitFindElement(By.ClassName("mod-add"));
            btnCreateNewBoard.Click();

            IWebElement inputBoardName = Driver.WaitFindElement(By.XPath("//input[@placeholder='Add board title']"));
            inputBoardName.SendKeys(boardName);
            
            IWebElement btnColorElement = Driver.WaitFindElement(By.XPath($"//button[@title='{color}']"));
            btnColorElement.Click();
            
            IWebElement btnTeamVisible = Driver.WaitFindElement(By.XPath("//button[text()='Team visible']"));
            btnTeamVisible.Click();

            IWebElement btnPermissionLevel = Driver.WaitFindElement(By.XPath($"//span[text()='{permission}']"));
            btnPermissionLevel.Click();

            IWebElement btnCreateBoard = Driver.WaitFindElement(By.XPath("//button[text()='Create board']"));
            btnCreateBoard.Click();
        }

        public void GoToBoardDetails(string name)
        {
            IWebElement boardName = Driver.WaitFindElement(By.XPath($"//div[@title='{name}']"));
            boardName.Click();
        }
    }
}