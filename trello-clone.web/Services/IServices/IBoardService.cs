using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;

namespace trello_clone.web.Services.IServices
{
    public interface IBoardService
    {
        Task<Board> GetBoard(string boardId, string Token);
        Task<List<List>> GetListsOfBoard(string boardId, string Token);
    }
}
