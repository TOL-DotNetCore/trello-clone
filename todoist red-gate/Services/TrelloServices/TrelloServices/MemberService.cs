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
    public class MemberService : IMemberService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;
        public MemberService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = TrelloAuthenticationController.OAuthToken;
        }
        public async Task<Member> Get(string memberId)
        {
            string url = BaseUrl + "/members/" + memberId + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.RequestMessage.Content.ReadAsStringAsync().ToString());
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Member>(content);
        }

        public async Task<List<Models.Action>> GetActionsOfMember(string memberId)
        {
            string url = BaseUrl + "/members/" + memberId + "/actions" + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.Action>>(content);
            return tasks;
        }

        public async Task<Member> Update(string memberId, Models.Member memberToUpdate)
        {
            string url = BaseUrl + "/members/" + memberId + "?key=" + AppKey + "&token=" + Token;
            var taskUpdate = JsonConvert.SerializeObject(memberToUpdate);
            var httpResponse = await _client.PutAsync(url, new StringContent(taskUpdate, Encoding.UTF8, "application/json"));
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.RequestMessage.Content.ReadAsStringAsync().Result);
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Member>(content);
            return task;
        }
    }
}
