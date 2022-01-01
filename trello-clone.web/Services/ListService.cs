using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Models;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Services
{
    public class ListService : IListService
    {
        public List<Card> GetCardsOfList(string listId)
        {
            throw new NotImplementedException();
        }
    }
}
