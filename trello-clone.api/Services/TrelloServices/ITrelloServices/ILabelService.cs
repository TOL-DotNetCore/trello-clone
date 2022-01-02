using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface ILabelService
    {
        Task<Models.Label> Get(string id, string Token);
        Task<Models.Label> Update(string id, Models.Label task, string Token);
        Task Delete(string id, string Token);
        Task<Models.Label> Create(string idBoard, string name, string color, string Token);
    }
}
