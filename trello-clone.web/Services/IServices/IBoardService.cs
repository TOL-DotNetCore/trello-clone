using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;

namespace trello_clone.web.Services.IServices
{
    public interface IBoardService
    {
        public Task<Board> GetBoard(string boardId);
        public Task<List<List>> GetListsOfBoard(string boardId);
    }
}
