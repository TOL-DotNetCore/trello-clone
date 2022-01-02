using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IMemberService
    {
        Task<Models.Member> Get(string memberId, string Token);
        Task<Models.Member> Update(string memberId, Models.Member memberToUpdate, string Token);
        Task<List<Models.Action>> GetActionsOfMember(string memberId, string Token);
    }
}
