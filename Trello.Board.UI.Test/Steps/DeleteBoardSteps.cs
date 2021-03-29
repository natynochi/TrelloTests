using NUnit.Framework;
using TechTalk.SpecFlow;
using Trello.Board.UI.Test.Pages;
using TrelloTests.Services;

namespace Trello.Board.UI.Test.Steps
{
    [Binding]
    public class DeleteBoardSteps
    {
        private readonly HomePage _homePage;
        private readonly BoardPage _boardPage;
        private readonly BoardServices _services;


        public DeleteBoardSteps(HomePage homePage, BoardPage boardPage)
        {
            _homePage = homePage;
            _boardPage = boardPage;
            _services = new BoardServices();
        }

        [Given(@"a existent board (.+)")]
        public void GivenAExistentBoardName(string name)
        {
            _services.PostDefaultBoard(name);
        }

        [When(@"the user delete the board (.+)")]
        public void WhenTheUserDeleteTheBoardName(string name)
        {
            _homePage.GoToBoardDetails(name);
            _boardPage.DeleteBoard();
        }

        [Then(@"board should not be displayed in the home page anymore")]
        public void ThenBoardShouldNotBeDisplayedInTheHomePageAnymore()
        {
            Assert.True(_boardPage.BoardNotFoundMessage().Displayed);
        }
    }
}