using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IBoardService
    {
        Task<Models.Board> Get(string id);
        Task<Models.Board> Update(string id, Models.Board task);
        Task Delete(string id);
    }
}
