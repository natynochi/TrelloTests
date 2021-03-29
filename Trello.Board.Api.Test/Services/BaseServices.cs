using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;

namespace TrelloTests.Services
{
    public class BaseServices
    {
        protected RestClient Client { get; }
        protected IRestRequest Request { get; private set; }
        public IConfiguration Configuration { get; }

        public BaseServices()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var baseUrl = Configuration.GetSection("ApiUrl").Value;
            Client = new RestClient(baseUrl);
        }

        protected void InitRequest(string resources, Method method)
        {
            var apiKey = Configuration.GetSection("ApiKey").Value;
            var token = Configuration.GetSection("Token").Value;

            Request = new RestRequest(resources, method);
            Request.AddQueryParameter("key", apiKey);
            Request.AddQueryParameter("token", token);
        }

        public async Task<IRestResponse<T>> ExecuteRequest<T>() where T : class
        {
            return await Client.ExecuteAsync<T>(Request);
        }

        public bool VerifySchema(string filePath, IRestResponse response)
        {
            string jsonSchema = File.ReadAllText(filePath);
            JSchema schema = JSchema.Parse(jsonSchema);
            JObject jsonResponse = JObject.Parse(response.Content);

            return jsonResponse.IsValid(schema, out IList<ValidationError> errors);
        }
    }
}