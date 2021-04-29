using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class ChecklistService : IChecklistService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;

        public ChecklistService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = "16a827c827226d35375b00936d65bea64d6c964f8e2e638f87fb9b27143eae7d";
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
