using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSampleProject.Steps
{
    [Binding]
    public sealed class Zippopotam
    {     

        private readonly ScenarioContext _scenarioContext;
        private static HttpClient client;
        private HttpResponseMessage response;
        private string baseaddress = "http://api.zippopotam.us/us/";

        public Zippopotam(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a user is connected to the zippotam url")]
        public void GivenAUserIsConnectedToTheZippotamUrl()
        {
            client = new HttpClient(); 
        }

        [When(@"the user enters a (.*)")]
        public async void WhenTheUserEntersAZipcode(int p0)
        {
            _scenarioContext["Zipcode"] = p0;
        }          
             
        private async Task<ZippoInfo> CallZippoApiAsync(string zip)
        {
            ZippoInfo body;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseaddress}{zip}"),               
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadFromJsonAsync<ZippoInfo>();
                Console.WriteLine(body);
            }
            return body;
        }

        [Then(@"the (.*),(.*) details are returned")]
        public async Task ThenTheBeverlyHillsDetailsAreReturnedAsync(string _placename,string state)
        {
            int zipcode = (int)_scenarioContext["Zipcode"];
            ZippoInfo _zippoinfo = await CallZippoApiAsync("" + zipcode);
            Assert.Multiple(() =>
               {
                   Assert.AreEqual(_placename.Trim(),_zippoinfo.places[0].placename);
                   Assert.AreEqual(state.Trim(),_zippoinfo.places[0].stateabbreviation);
               });
           
        }


    }
}
