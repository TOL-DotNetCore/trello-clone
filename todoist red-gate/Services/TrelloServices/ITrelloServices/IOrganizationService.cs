using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IOrganizationService
    {
        Task<Models.Organization> Get(string organizationId);
        Task<Models.Organization> Update(string organizationId, Models.Organization orgToUpdate);
        Task Delete(string organizationId);
        Task<Models.Organization> Create(string displayName);
    }
}
