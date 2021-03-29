using NUnit.Framework;
using TechTalk.SpecFlow;
using Trello.Board.UI.Test.Pages;

namespace Trello.Board.UI.Test.Steps
{
    [Binding]
    public class UpdateBoardSteps
    {
        private readonly HomePage _homePage;
        private readonly BoardPage _boardPage;


        public UpdateBoardSteps(HomePage homePage, BoardPage boardPage)
        {
            _homePage = homePage;
            _boardPage = boardPage;
        }

        [When(@"the user update the board (.+) for (.+)")]
        public void WhenTheUserUpdateTheBoard(string name, string new_permission)
        {
            _homePage.GoToBoardDetails(name);
            _boardPage.UpdateBoardPermissionLevel(new_permission);
        }

        [Then(@"the board (.+) (.+) must be seen in the board detail")]
        public void ThenTheBoardNewDataMustBeSeenInTheBoardDetail(string name, string new_permission)
        {
            Assert.AreEqual(new_permission, _boardPage.VerifyBoardPermission());

        }
    }
}