using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Services.TrelloServices.ITrelloServices
{
    public interface IEmojiService
    {
        Task<Models.Emoji> GetAll(string Token);
    }
}
