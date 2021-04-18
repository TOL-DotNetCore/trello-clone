using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices;

namespace todoist_red_gate.Services
{
    public class ListService : IListService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private IConfiguration _iConfig;
        private string AppKey;
        private string Token;
        public ListService(HttpClient client, IConfiguration iConfig)
        {
            _client = client;
            _iConfig = iConfig;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = "16a827c827226d35375b00936d65bea64d6c964f8e2e638f87fb9b27143eae7d";
        }


        public async Task<List> CreateListAsync(List task)
        {
            var content = JsonConvert.SerializeObject(task);
            string url = BaseUrl + "/lists?key=" + AppKey + "&token=" + Token;
            var httlResponse = await _client.PostAsync(url, new StringContent(content));
            if (!httlResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not add todo task");
            }
            var createdTask = JsonConvert.DeserializeObject<List>(await httlResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteListAsync(string id)
        {
            string url = BaseUrl + "/lists/";
            var httpResponse = await _client.DeleteAsync($"{url}{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the todo item");
            }
        }

        public async Task<List<Models.List>> GetAllListssAsync()
        {
            string boardId = "60546b95fb979e80fb292663";
            string url = BaseUrl + "/boards/" + boardId+"/lists?key="+AppKey+"&token=" + Token;
            var httpResponse = await _client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.List>>(content);

            return tasks;
        }

        public Task<List<Card>> GetCardsInAList()
        {
            throw new NotImplementedException();
        }

        public async Task<List> GetListAsync(string idList)
        {
            string url = BaseUrl + "/lists/" + idList + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var listItem = JsonConvert.DeserializeObject<List>(content);
            return listItem;
        }


        public async Task<List> UpdateListAsync(List task, string idList)
        {
            var url = BaseUrl + "/lists/" + idList + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync(url, new StringContent(content));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update list");
            }

            var updatedTask = JsonConvert.DeserializeObject<List>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }
    }
}
