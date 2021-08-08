using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoist_red_gate.Controllers;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class SearchService : IsearchService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;
        public SearchService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = TrelloAuthenticationController.OAuthToken;
        }
        public async Task<List<Member>> SearchMember(string query)
        {
            string url = BaseUrl + "/search/members/?key=" + AppKey + "&token=" + Token + "&query=" + query;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.Member>>(content);
            return tasks;
        }

        public async Task<List<object>> SearchTrello(string query)
        {
            string url = BaseUrl + "/search?key=" + AppKey + "&token=" + Token + "&query=" + query;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<List<object>>(content);
            return task;
        }
    }
}
