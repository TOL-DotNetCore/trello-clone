using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;

namespace trello_clone.web.Services.IServices
{
    public interface IListService
    {
        public Task<List<Card>> GetCardsOfList(string listId, string Token);
    }
}
