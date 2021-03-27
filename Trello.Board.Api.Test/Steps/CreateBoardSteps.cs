using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloTests.Services;

namespace TrelloTests.Steps
{
    [Binding]
    public class CreateBoardSteps
    {
        private readonly BoardServices _services;
        private IRestResponse _response;

        public CreateBoardSteps()
        {
            _services = new BoardServices();
        }

        [When(
            @"a user execute a POST requisition with the parameters (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) (.+) and (.+) to create a board")]
        public void WhenAUserExecuteAPostRequisitionToCreateABoard(string name, string desc, string idOrganization,
            string idBoardSource, string keepFromSource, string powerUps, string defaultLabels, string defaultLists,
            string prefs_permissionLevel, string prefs_voting, string prefs_comments, string prefs_invitations,
            string prefs_selfJoin, string prefs_cardCovers, string prefs_background, string prefs_cardAging)
        {
            _response = _services.CreateBoard(
                name, desc, idOrganization, idBoardSource, keepFromSource, powerUps,
                defaultLabels, defaultLists, prefs_permissionLevel, prefs_voting,
                prefs_comments, prefs_invitations, prefs_selfJoin, prefs_cardCovers,
                prefs_background, prefs_cardAging);
        }

        [Then(@"a status code response (.+) must be returned")]
        public void ThenAStatusCodeResponseMustBeReturned(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _response.StatusCode);
        }

        [Then(@"a valid response body content must be returned")]
        public void ThenAValidResponseBodyContentMustBeReturned()
        {
            Assert.True(_services.VerifySchema(@"../../../Data/board.schema.json", _response));
        }
    }
}