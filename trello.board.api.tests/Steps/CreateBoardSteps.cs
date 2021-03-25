using System;
using TechTalk.SpecFlow;

namespace TrelloTests.Steps
{
    [Binding]
    public class CreateBoardSteps
    {
        [When(@"a user execute a POST requisition with the parameters (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) and (.*) to create a board")]
        public void WhenAUserExecuteAPostRequisitionToCreateABoard(string name, string desc, string idOrganization,
            string idBoardSource, string keepFromSource, string powerUps, bool defaultLabels, bool defaultLists,
            string prefs_permissionLevel, string prefs_voting, string prefs_comments, string prefs_invitations,
            bool prefs_selfJoin, bool prefs_cardCovers, string prefs_background, string prefs_cardAging)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"a status code response (\d*) must be returned")]
        public void ThenAStatusCodeResponse200MustBeReturned()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"a valid response body content must be returned")]
        public void ThenAValidResponseBodyContentMustBeReturned()
        {
            ScenarioContext.StepIsPending();
        }
    }
}