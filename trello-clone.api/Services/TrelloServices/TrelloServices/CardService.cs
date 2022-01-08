using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private readonly IHttpClientFactory _clientFactory;
        private readonly string AppKey;
        private readonly IConfiguration _config;

        public CardService(HttpClient client, IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _client = client;
            _config = config;
            AppKey = _config.GetValue<string>("Trello:ConsumerKey");
        }
        public async Task<Card> CreateCardAsync(Card obj, string idList, string Token)
        {

            string url = BaseUrl + "/cards?key=" + AppKey + "&token=" + Token + "&idList=" + idList;
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                request.Content = content;
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");

                var response = await _client.SendAsync(request);
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Card>(jsonString);
            }
        }
        public async Task DeleteCardAsync(string id, string Token)
        {
            string url = BaseUrl + "/cards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the card item");
            }
        }

        public async Task<Models.Card> GetCardAsync(string id, string Token)
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
        public async Task<Card> UpdateCardAsync(Card task, string idCard, string Token)
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
        public async Task<Models.Action> GetActionOnCard(string cardId, string Token)
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

        public async Task<Board> GetBoardCardIsOn(string cardId, string Token)
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

        public async Task<List<CheckItem>> GetCheckItemsOnTheCard(string cardId, string Token)
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

        public async Task<List<Checklist>> GetCheckListsOnTheCard(string cardId, string Token)
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

        public async Task<List<Member>> GetMembersOfCards(string cardId, string Token)
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


        //Attachments
        public async Task<List<Attachment>> GetAttachmentsOnACard(string cardId, string Token)
        {
            string url = BaseUrl + "/cards/" + cardId + "/attachments?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Attachment>>(content);
        }

        public async Task<Attachment> GetAnAttachment(string cardId, string attachmentId, string Token)
        {
            string url = BaseUrl + "/cards/" + cardId + "/attachments/"+attachmentId+"?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Attachment>(content);
        }

        public async Task DeleteAttachment(string cardId, string attachmentId, string Token)
        {
            string url = BaseUrl + "/cards/" + cardId + "/attachments/" + attachmentId + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the card item");
            }
        }

        public Task<Attachment> CreateAttachment(string cardId, AttachmentCreateRequest request, string Token)
        {
            //var content = JsonConvert.SerializeObject(request);
            //string url = BaseUrl + "/cards/"+cardId+"/attachments?key=" + AppKey + "&token=" + Token;
            //NEED TO FIX IT
            //var multipartContent = new MultipartFormDataContent();
            //var fileContent = new ByteArrayContent(Convert.ToBase64String(request.file));
            //multipartContent.Add(fileContent, request.name, "upload.jpg");
            //var httpResponse = await _client.PostAsync(url, multipartContent);
            //if (!httpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Can not add card " + httpResponse.StatusCode);
            //}
            //var createdTask = JsonConvert.DeserializeObject<Attachment>(await httpResponse.Content.ReadAsStringAsync());
            //return createdTask;
            throw new NotImplementedException();
        }

        public async Task<Models.Action> CreateComment(string cardId, string text, string Token)
        {
            string url = BaseUrl + "/cards/" + cardId + "/actions/comments?text=" + text + "&key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.PostAsync(url, null);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot create comment");
            }
            string jsonString = await httpResponse.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Models.Action>(jsonString);
            return res;
        }
    }
}
