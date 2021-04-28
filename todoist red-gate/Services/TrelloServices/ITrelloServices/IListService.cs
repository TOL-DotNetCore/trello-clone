using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services
{
    public interface IListService
    {
        Task<List<Card>> GetCardsInAList(string idList);
        Task<List> GetListAsync(string id);
        Task<Board> GetBoardAListIsOn(string listId);
        
        Task<List> CreateListAsync(string listName, string idBoard);
        Task<List> UpdateListAsync(List task, string idList);
        Task ArchiveAsync(string id);
    }
}
