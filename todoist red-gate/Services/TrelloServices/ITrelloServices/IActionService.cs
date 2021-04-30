using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IActionService
    {
        Task<Models.Action> Get(string actionId);
        Task<Models.Action> Update(string actionId, string text);
        Task Delete(string actionId);
        Task<Models.Board> GetTheBoardForAnAction(string actionId);
    }
}
