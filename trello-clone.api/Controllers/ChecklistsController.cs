using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistsController : ControllerBase
    {
        private IChecklistService _checklistService;
        public ChecklistsController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet("{id}")]
        public async Task<Models.Checklist> Get(string id, string Token)
        {
            var task = await _checklistService.Get(id, Token);
            return task;
        }

        [HttpGet("{checkListId}/checkitems")]
        public async Task<List<Models.CheckItem>> GetCheckitemOn(string checkListId, string Token)
        {
            var tasks = await _checklistService.GetCheckItemOn(checkListId, Token);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Checklist> Update([FromBody] Models.Checklist checklistToUpdate, string id, string Token)
        {
            return await _checklistService.Update(id, checklistToUpdate, Token);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id, string Token)
        {
            await _checklistService.Delete(id, Token);
        }
    }
}
