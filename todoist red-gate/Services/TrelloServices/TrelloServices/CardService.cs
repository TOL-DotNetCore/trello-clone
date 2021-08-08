using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using todoist_red_gate.Controllers;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class CardService : ICardService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly string AppKey;
        private readonly string Token;
        private readonly IConfiguration _config;

        public CardService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            var ConsumerKey = _config.GetValue<string>("Trello:ConsumerKey");
            AppKey = ConsumerKey;
            Token = TrelloAuthorizationController.OAuthToken;
        }
        public async Task<Card> CreateCardAsync(Card task, string idList)
        {

            var content = JsonConvert.SerializeObject(task);
            string url = BaseUrl + "/cards?key=" + AppKey + "&token=" + Token + "&idList=" + idList;
            var httpResponse = await _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not add card " + httpResponse.StatusCode);
            }
            var createdTask = JsonConvert.DeserializeObject<Card>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }
        public async Task DeleteCardAsync(string id)
        {
            string url = BaseUrl + "/cards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the card item");
            }
        }

        public async Task<Models.Card> GetCardAsync(string id)
        {
            string url = BaseUrl + "/cards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var cardItem = JsonConvert.DeserializeObject<Models.Card>(content);

            return cardItem;
        }
        public async Task<Card> UpdateCardAsync(Card task, string idCard)
        {
            var url = BaseUrl + "/cards/" + idCard + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update card");
            }

            var updatedTask = JsonConvert.DeserializeObject<Card>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }


        //NEED TO FIX
        public async Task<Models.Action> GetActionOnCard(string cardId)
        {
            string url = BaseUrl + "/cards/" + cardId + "/actions?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Action>(content);
        }

        public async Task<Board> GetBoardCardIsOn(string cardId)
        {
            string url = BaseUrl + "/cards/" + cardId + "/board?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Board>(content);
        }

        public async Task<List<CheckItem>> GetCheckItemsOnTheCard(string cardId)
        {
            string url = BaseUrl + "/cards/" + cardId + "/checkItemStates?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Models.CheckItem>>(content);
        }

        public async Task<List<Checklist>> GetCheckListsOnTheCard(string cardId)
        {
            string url = BaseUrl + "/cards/" + cardId + "/checkLists?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Models.Checklist>>(content);
        }

        public async Task<List<Member>> GetMembersOfCards(string cardId)
        {
            string url = BaseUrl + "/cards/" + cardId + "/members?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Member>>(content);
        }

        
    }
}
