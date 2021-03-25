using TechTalk.SpecFlow;

namespace TrelloTests.Steps
{
    [Binding]
    public class UpdateBoardSteps
    {
        [When(@"a user execute a PUT requisition for the board (.*) with the parameters (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)  and (.*) to update the board")]
        public void WhenAUserExecuteAPutRequisitionToUpdateABoard(string id, string name, string desc,  string closed, string subscribed, string idOrganization, string prefs_permissionLevel, string prefs_voting, string prefs_comments, string prefs_invitations, string prefs_selfJoin, string prefs_cardCovers, string prefs_background, string prefs_cardAging,  string prefs_calendarFeedEnabled,  string labelNames_green, string labelNames_yellow, string labelNames_orange, string labelNames_red, string labelNames_purple, string labelNames_blue)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"a response status code (\d*) must be returned")]
        public void ThenAResponseStatusCode200MustBeReturned()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"a valid response body content")]
        public void ThenAValidResponseBodyContent()
        {
            ScenarioContext.StepIsPending();
        }
    }
}