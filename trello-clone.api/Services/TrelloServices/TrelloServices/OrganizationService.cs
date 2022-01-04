using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using todoist_red_gate.Controllers;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class OrganizationService : IOrganizationService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly string AppKey;
        private readonly string Token;
        private readonly IConfiguration _config;
        public OrganizationService(HttpClient client, IConfiguration config)
        {
            _config = config;
            _client = client;
            AppKey = _config.GetValue<string>("Trello:ConsumerKey");
        }
        public async Task<Organization> Create(string displayName, string Token)
        {
            string url = BaseUrl + "/organizations?key=" + AppKey + "&token=" + Token + "&displayName=" + displayName;
            var httpResponse = await _client.PostAsync(url, null);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }

        public async Task Delete(string organizationId, string Token)
        {
            string url = BaseUrl + "/organizations/" + organizationId + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
        }

        public async Task<Organization> Get(string organizationId, string Token)
        {
            string url = BaseUrl + "/organizations/" +organizationId+ "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }

        public async Task<List<Board>> GetBoardsInOrganization(string organizationId, string Token)
        {
            string url = BaseUrl + "/organizations/" + organizationId + "/boards?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<List<Board>>(content);
            return res;
        }

        public async Task<Organization> Update(string organizationId, Organization orgToUpdate, string Token)
        {
            string url = BaseUrl + "/organizations/" + organizationId + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(orgToUpdate);
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var task = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }
    }
}
