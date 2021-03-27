using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;

namespace TrelloTests.Services
{
    public class BaseServices
    {
        protected RestClient Client { get; private set; }
        protected IRestRequest Request { get; private set; }

        protected void InitRequest(string resources, Method method)
        {
            dynamic config = ReadJsonFile(@"appsettings.json");
            string baseUrl = config["API"]["BaseUrl"];
            string apiKey = config["API"]["ApiKey"];
            string token = config["API"]["Token"];

            Client = new RestClient(baseUrl);
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

        public static dynamic ReadJsonFile(string file)
        {
            using (StreamReader json = new StreamReader(file))
            {
                var data = json.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(data);
            }
        }
    }
}