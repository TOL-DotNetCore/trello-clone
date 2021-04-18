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
        public async Task<Models.Label> Get(string id)
        {
            var tasks = await _labelService.Get(id);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Label> Update([FromBody] Models.Label labelToUpdate, string id)
        {
            return await _labelService.Update(id, labelToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _labelService.Delete(id);
        }
    }
}
