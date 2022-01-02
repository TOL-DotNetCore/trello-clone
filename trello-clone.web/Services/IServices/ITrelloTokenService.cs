using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Services.IServices
{
    public interface ITrelloTokenService
    {
        void SaveToken(string tlToken);
        string GetToken();
    }
}
