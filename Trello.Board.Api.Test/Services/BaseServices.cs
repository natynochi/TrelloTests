using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;

namespace TrelloTests.Services
{
    public class BaseServices
    {
        protected static RestClient Client { get; set; }

        public BaseServices(RestClient client)
        {
            Client = client;
        }

        public async Task<IRestResponse<T>> ExecuteRequest<T>(IRestRequest request, CancellationToken cancellationToken = default)
        { 
            return await Client.ExecuteAsync<T>(request, cancellationToken);
        }
    }
}