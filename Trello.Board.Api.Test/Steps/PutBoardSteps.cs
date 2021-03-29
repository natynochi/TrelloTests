using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloTests.Services;

namespace TrelloTests.Steps
{
    [Binding]
    public class PutBoardSteps
    {
        private readonly BoardServices _services;
        private IRestResponse _response;
        private string id;

        public PutBoardSteps()
        {
            _services = new BoardServices();
        }


        [Given(@"a pre existent board (.+)")]
        public void GivenAPreExistentBoard(string name)
        {
            id = _services.PostDefaultBoard(name);
        }

        [When(
            @"a user execute a PUT requisition for a board with the parameters (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) and (.+) to update the board")]
        public void WhenAUserExecuteAPutRequisitionToUpdateTheBoard(string name, string desc, string closed,
            string subscribed, string idOrganization, string prefs_permissionLevel, string prefs_voting,
            string prefs_comments, string prefs_invitations, string prefs_selfJoin, string prefs_cardCovers,
            string prefs_background, string prefs_cardAging, string prefs_calendarFeedEnabled, string labelNames_green)
        {
            _response = _services.PutBoard(id, name, desc, closed, subscribed, idOrganization, prefs_permissionLevel,
                prefs_voting, prefs_comments, prefs_invitations, prefs_selfJoin, prefs_cardCovers, prefs_background,
                prefs_cardAging, prefs_calendarFeedEnabled, labelNames_green);
        }

        [Then(@"a (.+) response status code response must be returned")]
        public void ThenAOKResponseStatusCodeResponseMustBeReturned(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _response.StatusCode);
        }

        [Then(@"a valid response body content")]
        public void ThenAValidResponseBodyContent()
        {
            Assert.True(_services.VerifySchema(@"../../../Data/board.schema.json", _response));
        }
    }
}