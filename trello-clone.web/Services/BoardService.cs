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
        public async Task<Board> GetBoard(string boardId)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/boards/" + boardId);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Board>(jsonString);
            }
            return null;
        }


        public async Task<List<List>> GetListsOfBoard(string boardId)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/boards/" + boardId + "/lists");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<List>>(jsonString);
            }
            return null;
        }
    }
}
