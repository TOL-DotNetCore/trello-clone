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
    public class ListService : IListService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ListService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Card>> GetCardsOfList(string listId, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/lists/" + listId + "/cards?Token=" + Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Card>>(jsonString);
            }
            return null;
        }
    }
}
