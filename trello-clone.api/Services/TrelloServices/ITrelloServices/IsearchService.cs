using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices
{
    public interface IsearchService
    {
        Task<List<object>> SearchTrello(string query);
        Task<List<Models.Member>> SearchMember(string query);
    }
}
