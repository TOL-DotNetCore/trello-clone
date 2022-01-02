using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoist_red_gate.Controllers;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class EmojiService : IEmojiService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly string AppKey;
        private readonly IConfiguration _config;

        public EmojiService(HttpClient client, IConfiguration config)
        {
            _config = config;
            _client = client;
            AppKey = _config.GetValue<string>("Trello:ConsumerKey");
        }

        public async Task<Models.Emoji> GetAll(string Token)
        {
            string url = BaseUrl + "/emoji?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            Models.Emoji task = JsonConvert.DeserializeObject<Models.Emoji>(content);
            return task;
        }
    }
}
