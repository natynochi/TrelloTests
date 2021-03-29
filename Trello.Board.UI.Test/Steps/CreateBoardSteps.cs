using TechTalk.SpecFlow;
using Trello.Board.UI.Test.Pages;

namespace Trello.Board.UI.Test.Steps
{
    [Binding]
    public class CreateBoardSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly BoardPage _boardPage;

        public CreateBoardSteps(LoginPage loginPage, HomePage homePage, BoardPage boardPage)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _boardPage = boardPage;
        }

        [Given(@"a user with trello access")]
        public void GivenAUserWithTrelloAccess()
        {
            _loginPage.Login();
        }

        [When(@"the user create a board (.+) with the permission level (.+) and (.+)")]
        public void WhenTheUserCreateABoardNameWithThePermissionLevelPermissionAndColor(string name, string permission, string color)
        {
            _homePage.CreateBoard(name, permission, color);
        }

        [Then(@"the new board (.+) area must be seen with the (.+) and (.+)")]
        public void ThenTheNewBoardNameAreaMustBeSeenWithThePermissionAndColorRgb(string name, string permission, string colorRGB)
        {
            _boardPage.VerifyBoardBasicInfo(name, permission, colorRGB);
        }
    }
}