using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchsController : ControllerBase
    {
        private IsearchService _searchService;
        public SearchsController(IsearchService searchService)
        {
            _searchService = searchService;
        }


        // NEED TO FIX IT
        [HttpGet("query={query}")]
        public async Task<Object> SearchTrelo(string query)
        {
            var task = await _searchService.SearchTrello(query);
            return task;
        }

        [HttpGet("members/query={query}")]
        public async Task<List<Models.Member>> SearchMember(string query)
        {
            var tasks = await _searchService.SearchMember(query);
            return tasks;
        }
    }
}
