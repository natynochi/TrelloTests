using TechTalk.SpecFlow;

namespace TrelloTests.Steps
{          
    [Binding]
    public class DeleteBoardSteps
    {
        [Given(@"a existent board")]
        public void GivenAExistentBoard()
        {
            ScenarioContext.StepIsPending();
        }
        
        [When(@"a user execute a DELETE requisition for the board (.*)")]
        public void WhenAUserExecuteADeleteRequisitionForTheBoardId(string id)
        {
            ScenarioContext.StepIsPending();
        }
        
        [Then(@"a response status code (\d*) must be returned")]
        public void ThenAResponseStatusCode200MustBeReturned()
        {
            ScenarioContext.StepIsPending();
        }
        
        [Then(@"the board must not exist anymore")]
        public void ThenTheBoardMustNotExistAnymore()
        {
            ScenarioContext.StepIsPending();
        }
    }
}