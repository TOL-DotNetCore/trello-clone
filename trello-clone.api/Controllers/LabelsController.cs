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
    public class LabelsController : ControllerBase
    {
        private ILabelService _labelService;
        public LabelsController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpGet("{id}")]
        public async Task<Models.Label> Get(string id, string Token)
        {
            var tasks = await _labelService.Get(id, Token);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Label> Update([FromBody] Models.Label labelToUpdate, string id, string Token)
        {
            return await _labelService.Update(id, labelToUpdate, Token);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id, string Token)
        {
            await _labelService.Delete(id, Token);
        }

        [HttpPost("idBoard={idBoard}&name={name}&color={color}")]
        public async Task<Models.Label> Create(string idBoard, string name, string color, string Token)
        {
            return await _labelService.Create(idBoard, name, color, Token);
        }
    }
}
