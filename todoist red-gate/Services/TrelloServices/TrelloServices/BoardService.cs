using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class BoardService : IBoardService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;

        public BoardService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = "16a827c827226d35375b00936d65bea64d6c964f8e2e638f87fb9b27143eae7d";
        }

        public async Task<Models.Board> Create(string nameBoard)
        {
            string url = BaseUrl + "/boards/?key=" + AppKey + "&token=" + Token + "&name=" + nameBoard;
            var httpResponse = await _client.PostAsync(url, null);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Board>(content);
            return task;
        }

        public async Task Delete(string id)
        {
            string url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not delelte");
            }
        }

        public async Task<Models.Board> Get(string id)
        {
            string url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var board = JsonConvert.DeserializeObject<Models.Board>(content);
            return board;
        }

        public async Task<List<Models.Membership>> GetMemberships(string idBoard)
        {
            string url = BaseUrl + "/boards/" + idBoard + "/memberships?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.Membership>>(content);
            return tasks;
        }

        public async Task<Models.Board> Update(string id, Models.Board task)
        {
            var url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            var httpResponse = await _client.PutAsync(url, new StringContent(content));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update label");
            }

            var updatedTask = JsonConvert.DeserializeObject<Models.Board>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }
    }
}
