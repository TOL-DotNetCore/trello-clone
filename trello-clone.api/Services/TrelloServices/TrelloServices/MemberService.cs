using Microsoft.Extensions.Configuration;
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
    public class MemberService : IMemberService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly string AppKey;
        public MemberService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            AppKey = _config.GetValue<string>("Trello:ConsumerKey");
        }
        public async Task<Member> Get(string memberId, string Token)
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

        public async Task<List<Models.Action>> GetActionsOfMember(string memberId, string Token)
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

        // Get current user
        public async Task<MemberGetInfo> GetCurrentInfo(string Token)
        {
            string url = BaseUrl + "/members/me?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var mem = JsonConvert.DeserializeObject<dynamic>(content);
            return new MemberGetInfo() { id = mem.id, username = mem.username, avatarUrl = mem.avatarUrl};
        }

        public async Task<List<Organization>> GetOrganizationsOfMember(string memberId, string Token)
        {
            string url = BaseUrl + "/members/" + memberId + "/organizations" + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Organization>>(content);
            return tasks;
        }

        public async Task<Member> Update(string memberId, Models.Member memberToUpdate, string Token)
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
