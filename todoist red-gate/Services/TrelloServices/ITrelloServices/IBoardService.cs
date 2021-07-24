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
        Task<List<Models.Membership>> GetMemberships(string idBoard);
        Task<Models.Board> Create(string nameBoard);
        Task<List<Models.Card>> GetAllCurentDateCardOfBoard(string boardId);
        Task<List<Models.Card>> GetAllCardBetween(string boardId, DateTime start, DateTime end);
        Task<Models.WeekSumary> GetSumaryOfWeek(string boardId);
        Task<List<Models.Card>> GetCardsUnfinished(string boardId);
        Task<List<Models.Card>> GetCardsUnfinished(string boardId, DateTime start, DateTime end);
        Task<List<Models.List>> GetListsOnBoard(string boardId);
    }
}
