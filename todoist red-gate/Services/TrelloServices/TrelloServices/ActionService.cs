using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class ActionService : IActionService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;

        public ActionService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = "16a827c827226d35375b00936d65bea64d6c964f8e2e638f87fb9b27143eae7d";
        }
        public async Task Delete(string actionId)
        {
            string url = BaseUrl + "/actions/" + actionId + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete this action");
            }
        }

        public async Task<Models.Action> Get(string actionId)
        {
            string url = BaseUrl + "/actions/" + actionId + "?key=" + AppKey + "&token=" + Token;
            var httpresponse = await _client.GetAsync(url);
            if(!httpresponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpresponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Action>(content);
            return task;
        }

        public async Task<Board> GetTheBoardForAnAction(string actionId)
        {
            string url = BaseUrl + "/actions/" + actionId + "/board" + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Board>(content);
        }

        public async Task<Models.Action> Update(string actionId, string text)
        {
            string url = BaseUrl + "/actions/" + actionId + "?text=" + text + "&key=" + AppKey + "&token=" + Token;
            var httpresponse = await _client.PutAsync(url, null);
            if (!httpresponse.IsSuccessStatusCode)
            {
                throw new Exception("action can't be edited");
            }
            var content = await httpresponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Action>(content);
            return task;
        }
    }
}
