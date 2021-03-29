using TechTalk.SpecFlow;
using Trello.Board.UI.Test.Context;

namespace Trello.Board.UI.Test.Utilities
{
    [Binding]
    public class Hooks
    {
        private readonly TrelloContext _context;

        public Hooks(TrelloContext context)
        {
            _context = context;
        }
        
        [BeforeScenario]
        protected void Init()
        {
            _context.Init();
        }
    }
}