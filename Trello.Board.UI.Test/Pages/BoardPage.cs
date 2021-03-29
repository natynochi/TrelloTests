using NUnit.Framework;
using OpenQA.Selenium;
using Trello.Board.UI.Test.Context;

namespace Trello.Board.UI.Test.Pages
{
    public class BoardPage : BasePage
    {
        public BoardPage(TrelloContext driver) : base(driver)
        {
        }

        public void UpdateBoardPermissionLevel(string new_permission)
        {
            IWebElement boardPermissionTag = Driver.WaitFindElement(By.Id("permission-level"));
            boardPermissionTag.Click();

            IWebElement btnPermissionLevel = Driver.WaitFindElement(By.Name($"{new_permission.ToLower()}"));
            btnPermissionLevel.Click();

            if (new_permission == "Public")
                Driver.WaitFindElement(By.ClassName("make-public-confirmation-button")).Click();
            
        }

        public void CloseBoard()
        {
            IWebElement btnMore = Driver.WaitFindElement(By.ClassName("js-open-more"));
            btnMore.Click();

            IWebElement btnClose = Driver.WaitFindElement(By.ClassName("js-close-board"));
            btnClose.Click();

            IWebElement btnConfirmClose = Driver.WaitFindElement(By.ClassName("nch-button--danger"));
            btnConfirmClose.Click();
        }

        public void DeleteBoard()
        {
            CloseBoard();

            IWebElement linkDelete = Driver.WaitFindElement(By.ClassName("js-delete"));
            linkDelete.Click();

            IWebElement linkConfirmDelete = Driver.WaitFindElement(By.ClassName("nch-button--danger"));
            linkConfirmDelete.Click();
        }

        public IWebElement BoardNotFoundMessage()
        {
            return Driver.WaitFindElement(By.XPath("//*[text()='Board not found.']"));
        }
        
        public string VerifyBoardPermission()
        {
            return Driver.WaitFindElement(By.Id("permission-level")).Text;
        }
        
        public void VerifyBoardBasicInfo(string name, string permission, string colorRGB)
        {
            IWebElement boardNameTag = Driver.WaitFindElement(By.ClassName("mod-board-name"));
            Assert.AreEqual(name, boardNameTag.Text);
            
            Assert.AreEqual(permission, VerifyBoardPermission());

            IWebElement boardColor = Driver.WaitFindElement(By.ClassName("js-fill-background-preview"));
            Assert.AreEqual(boardColor.GetCssValue("background-color"), colorRGB);
        }
    }
}