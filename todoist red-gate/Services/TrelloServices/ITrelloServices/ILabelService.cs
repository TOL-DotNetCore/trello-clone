using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface ILabelService
    {
        Task<Models.Label> Get(string id);
        Task<Models.Label> Update(string id, Models.Label task);
        Task Delete(string id);
    }
}
