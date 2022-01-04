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
    public class OrganizationService : IOrganizationService
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrganizationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Board>> GetBoardsOfOrg(string orgId, string Token)
        {
            var client = _clientFactory.CreateClient();
            string url = WC.ApiUrl + "/organizations/" + orgId + "/boards?Token=" + Token;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Board>>(jsonString);
            }
            return null;
        }

    }
}
