using System;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloTests.Model;
using TrelloTests.Services;

namespace TrelloTests.Steps
{
    [Binding]
    public class CreateBoardSteps : BaseServices
    {
        public CreateBoardSteps(RestClient _client) : base(Client)
        {
        }

        private IRestResponse _response;


        [When(
            @"a user execute a POST requisition with the parameters (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) and (.*) to create a board")]
        public void WhenAUserExecuteAPostRequisitionToCreateABoard(string name, string desc, string idOrganization,
            string idBoardSource, string keepFromSource, string powerUps, bool defaultLabels, bool defaultLists,
            string prefs_permissionLevel, string prefs_voting, string prefs_comments, string prefs_invitations,
            bool prefs_selfJoin, bool prefs_cardCovers, string prefs_background, string prefs_cardAging)
        {
            Client = new RestClient(
                "https://api.trello.com/1/boards/?key=403bd28746c7fa743c74dfb224fefd77&token=a3e211d8ad9200d937249cf799e9beeaa8173d460a0972a1b9a667c331508b36");

            var request = new RestRequest("post", Method.POST);
            request.AddQueryParameter("name", name);
            request.AddParameter("desc", desc);
            request.AddParameter("keepFromSource", keepFromSource);
            request.AddParameter("powerUps", powerUps);
            request.AddParameter("defaultLabels", defaultLabels);
            request.AddParameter("defaultLists", defaultLists);
            request.AddParameter("prefs_permissionLevel", prefs_permissionLevel);
            request.AddParameter("prefs_voting", prefs_voting);
            request.AddParameter("prefs_comments", prefs_comments);
            request.AddParameter("prefs_invitations", prefs_invitations);
            request.AddParameter("prefs_selfJoin", prefs_selfJoin);
            request.AddParameter("prefs_cardCovers", prefs_cardCovers);
            request.AddParameter("prefs_background", prefs_background);
            request.AddParameter("prefs_cardAging", prefs_cardAging);

            if (idOrganization != "null" || idOrganization != "")
                request.AddParameter("idOrganization", idOrganization);

            if (idBoardSource != "null" || idBoardSource != "")
                request.AddParameter("idBoardSource", idBoardSource);

            _response = ExecuteRequest<CreateBoard>(request).GetAwaiter().GetResult();
        }

        [Then(@"a status code response (\d*) must be returned")]
        public void ThenAStatusCodeResponse200MustBeReturned(int statusCode)
        {
            Assert.Equals(_response.StatusCode, statusCode);
        }

        [Then(@"a valid response body content must be returned")]
        public void ThenAValidResponseBodyContentMustBeReturned()
        {
        }
    }
}