using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IBoardService
    {
        Task<Models.Board> Get(string id, string Token);
        Task<Models.Board> Update(string id, Models.Board task, string Token);
        Task Delete(string id, string Token);
        Task<List<Models.Membership>> GetMemberships(string idBoard, string Token);
        Task<Models.Board> Create(string nameBoard, string Token);
        Task<List<Models.Card>> GetAllCurentDateCardOfBoard(string boardId, string Token);
        Task<List<Models.Card>> GetAllCardBetween(string boardId, DateTime start, DateTime end, string Token);
        Task<Models.WeekSumary> GetSumaryOfWeek(string boardId, string Token);
        Task<List<Models.Card>> GetCardsUnfinished(string boardId, string Token);
        Task<List<Models.Card>> GetCardsUnfinished(string boardId, DateTime start, DateTime end, string Token);
        Task<List<Models.List>> GetListsOnBoard(string boardId, string Token);
    }
}
