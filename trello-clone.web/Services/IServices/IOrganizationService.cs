using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;

namespace trello_clone.web.Services.IServices
{
    public interface IOrganizationService
    {
        Task<List<Board>> GetBoardsOfOrg(string orgId, string Token);
    }
}
