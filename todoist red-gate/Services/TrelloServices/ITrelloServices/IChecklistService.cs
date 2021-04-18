using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IChecklistService
    {
        Task<Models.Checklist> Get(string id);
        Task<Models.Checklist> Update(string id, Models.Label task);
        Task Delete(string id);
        Task<List<Models.CheckItem>> GetCheckItemOn(string id);
    }
}
