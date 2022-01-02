using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services
{
    public interface IListService
    {
        Task<List<Card>> GetCardsInAList(string idList, string Token);
        Task<List> GetListAsync(string id, string Token);
        Task<Board> GetBoardAListIsOn(string listId, string Token);
        
        Task<List> CreateListAsync(string listName, string idBoard, string Token);
        Task<List> UpdateListAsync(List task, string idList, string Token);
        Task ArchiveAsync(string id, string Token);
    }
}
