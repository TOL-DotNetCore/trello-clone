using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using trello_clone.web.Models;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Services
{
    public class BoardService : IBoardService
    {
        private readonly IHttpClientFactory _clientFactory;
        public BoardService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Board> Create(string nameBoard, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.PostAsync(WC.ApiUrl + "/boards/" + nameBoard + "?Token=" + Token, null);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Board>(jsonString);
            }
            return null;
        }

        public async Task<Board> GetBoard(string boardId, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/boards/" + boardId + "?Token=" + Token);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Board>(jsonString);
            }
            return null;
        }


        public async Task<List<List>> GetListsOfBoard(string boardId, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/boards/" + boardId + "/lists?Token=" + Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<List>>(jsonString);
            }
            return null;
        }
    }
}
