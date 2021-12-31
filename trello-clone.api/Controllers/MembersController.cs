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
    public class MembersController : ControllerBase
    {
        private IMemberService _memberService;
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("{memberId}")]
        public async Task<Models.Member> Get(string memberId)
        {
            var task = await _memberService.Get(memberId);
            return task;
        }

        [HttpGet("{memberId}/actions")]
        public async Task<List<Models.Action>> GetActionsOfMember(string memberId)
        {
            var tasks = await _memberService.GetActionsOfMember(memberId);
            return tasks;
        }

        [HttpPut("{memberId}")]
        public async Task<Models.Member> Update(string memberId, [FromBody] Models.Member memberToUpdate)
        {
            var task = await _memberService.Update(memberId, memberToUpdate);
            return task;
        }
    }
}
