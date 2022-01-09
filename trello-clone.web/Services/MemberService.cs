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
    public class MemberService : IMemberService
    {
        private readonly IHttpClientFactory _clientFactory;
        public MemberService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<BoardStar>> GetBoardStarsOfMeber(string memberId, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/members/" + memberId + "/boardStars?Token=" + Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BoardStar>>(jsonString);
            }
            return null;
        }

        // Get current user login information
        public async Task<MemberGetInfo> GetCurrentInfo(string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/members/me?Token=" + Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MemberGetInfo>(jsonString);
            }
            return null;
        }

        public async Task<List<Organization>> GetOrganizationsOfMember(string memberId, string Token)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(WC.ApiUrl + "/members/" + memberId + "/organizations?Token=" + Token);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Organization>>(jsonString);
               
            }
            return null;
        }


    }
}
