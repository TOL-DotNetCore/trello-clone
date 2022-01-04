using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;
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
        public async Task<Models.Member> Get(string memberId, string Token)
        {
            var task = await _memberService.Get(memberId, Token);
            return task;
        }

        [HttpGet("{memberId}/actions")]
        public async Task<List<Models.Action>> GetActionsOfMember(string memberId, string Token)
        {
            var tasks = await _memberService.GetActionsOfMember(memberId, Token);
            return tasks;
        }

        [HttpPut("{memberId}")]
        public async Task<Models.Member> Update(string memberId, [FromBody] Models.Member memberToUpdate, string Token)
        {
            var task = await _memberService.Update(memberId, memberToUpdate, Token);
            return task;
        }

        [HttpGet("{memberId}/organizations")]
        public async Task<List<Organization>> GetOrganizationsOfMember(string memberId, string Token)
        {
            var tasks = await _memberService.GetOrganizationsOfMember(memberId, Token);
            return tasks;
        }

        [HttpGet("me")]
        public async Task<Member> GetCurrentInfo(string Token)
        {
            var res = await _memberService.GetCurrentInfo(Token);
            return res;
        }
    }
}
