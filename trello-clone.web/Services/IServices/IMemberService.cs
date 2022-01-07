using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;

namespace trello_clone.web.Services.IServices
{
    public interface IMemberService
    {
        Task<List<Organization>> GetOrganizationsOfMember(string memberId, string Token);
        Task<MemberGetInfo> GetCurrentInfo(string Token);
    }
}
