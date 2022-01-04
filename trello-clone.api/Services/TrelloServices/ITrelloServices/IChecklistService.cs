using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IChecklistService
    {
        Task<Models.Checklist> Get(string id, string Token);
        Task<Models.Checklist> Update(string id, Models.Checklist task, string Token);
        Task Delete(string id, string Token);
        //Task<Models.Checklist> Create(string idCard, Models.Checklist task);
        Task<List<Models.CheckItem>> GetCheckItemOn(string id, string Token);
    }
}
