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
        public async Task<Models.Checklist> Get(string id)
        {
            var task = await _checklistService.Get(id);
            return task;
        }

        [HttpGet("{checkListId}/checkitems")]
        public async Task<List<Models.CheckItem>> GetCheckitemOn(string checkListId)
        {
            var tasks = await _checklistService.GetCheckItemOn(checkListId);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Checklist> Update([FromBody] Models.Label checklistToUpdate, string id)
        {
            return await _checklistService.Update(id, checklistToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _checklistService.Delete(id);
        }
    }
}
