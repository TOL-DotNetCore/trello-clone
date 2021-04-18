using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services
{
    public interface IListService
    {
        Task<List<Card>> GetCardsInAList();
        Task<List> GetListAsync(string id);
        Task<List<List>> GetAllListssAsync();
        
        Task<List> CreateListAsync(List task);
        Task<List> UpdateListAsync(List task, string idList);
        Task DeleteListAsync(string id);
    }
}
