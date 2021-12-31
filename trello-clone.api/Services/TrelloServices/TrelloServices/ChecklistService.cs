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
    public class ChecklistService : IChecklistService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly string AppKey;
        private readonly string Token;
        private readonly IConfiguration _config;

        public ChecklistService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            var ConsumerKey = _config.GetValue<string>("Trello:ConsumerKey");
            AppKey = ConsumerKey;
            Token = TrelloAuthorizationController.OAuthToken;
        }

        public async Task Delete(string id)
        {
            string url = BaseUrl + "/checklists/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not delelte");
            }
        }

        public async Task<Checklist> Get(string id)
        {
            string url = BaseUrl + "/checklists/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Checklist>(content);
            return task;
        }

        public async Task<List<CheckItem>> GetCheckItemOn(string id)
        {
            var url = BaseUrl + "/checklists/" + id + "/checkItems?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not retrieve tasks");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.CheckItem>>(content);
            return tasks;
        }

        public async Task<Checklist> Update(string id, Checklist task)
        {
            var url = BaseUrl + "/checklists/" + id + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update checklist");
            }

            var updatedTask = JsonConvert.DeserializeObject<Models.Checklist>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }
    }
}
