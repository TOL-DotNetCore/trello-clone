using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IActionService
    {
        Task<Models.Action> Get(string actionId, string Token);
        Task<Models.Action> Update(string actionId, string text, string Token);
        Task Delete(string actionId, string Token);
        Task<Models.Board> GetTheBoardForAnAction(string actionId, string Token);
    }
}
