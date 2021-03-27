using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloTests.Model;
using TrelloTests.Services;

namespace TrelloTests.Steps
{
    [Binding]
    public class DeleteBoardSteps
    {
        private readonly BoardServices _services;
        private IRestResponse _response;
        private string id;

        public DeleteBoardSteps()
        {
            _services = new BoardServices();
        }

        [Given(@"a existent board (.+)")]
        public void GivenAExistentBoard(string name)
        {
            id = _services.CreateDefaultBoard(name);
        }

        [When(@"a user execute a DELETE requisition for a board")]
        public void WhenAUserExecuteADeleteRequisitionForABoard()
        {
            _response = _services.DeleteBoard(id);
        }

        [Then(@"a response status code (.+) must be returned")]
        public void ThenAResponseStatusCodeOkMustBeReturned(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _response.StatusCode);
        }

        [Then(@"the board must be (.+) anymore")]
        public void ThenTheBoardMustBeNotFoundAnymore(HttpStatusCode statusCode)
        {
            _response = _services.GetBoard(id);
            Assert.AreEqual(statusCode, _response.StatusCode);
        }
    }
}