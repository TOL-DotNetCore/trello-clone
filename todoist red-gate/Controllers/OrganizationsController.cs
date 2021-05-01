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
    public class OrganizationsController : ControllerBase
    {
        private IOrganizationService _organizationService;
        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet("{organizationId}")]
        public async Task<Models.Organization> Get(string organizationId)
        {
            var task = await _organizationService.Get(organizationId);
            return task;
        }

        [HttpPut("{organizationId}")]
        public async Task<Models.Organization> Update(string organizationId, Models.Organization orgToUpdate)
        {
            var task = await _organizationService.Update(organizationId, orgToUpdate);
            return task;
        }

        [HttpDelete("{organizationId}")]
        public async Task Delete(string organizationId)
        {
            await _organizationService.Delete(organizationId);
        }
    }
}
