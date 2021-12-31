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


    public class ActionsController : ControllerBase
    {
        private IActionService _actionService;
        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("{actionId}")]
        public async Task<Models.Action> Get(string actionId)
        {
            var task = await _actionService.Get(actionId);
            return task;
        }
        [HttpPut("{actionId}/text={text}")]
        public async Task<Models.Action> Update(string actionId, string text)
        {
            var task = await _actionService.Update(actionId, text);
            return task;
        }

        [HttpGet("{actionId}/board")]
        public async Task<Models.Board> GetTheBoardForAnAction(string actionId)
        {
            var task = await _actionService.GetTheBoardForAnAction(actionId);
            return task;
        }

        [HttpDelete("{actionId}")]
        public async Task Delete(string actionId)
        {
            await _actionService.Delete(actionId);
        }

    }
}
