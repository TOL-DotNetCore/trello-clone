using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Controllers
{
    [Route("api/emoji")]
    [ApiController]
    public class EmojisController : ControllerBase
    {
        private IEmojiService _emojiService;
        public EmojisController(IEmojiService emojiService)
        {
            _emojiService = emojiService;
        }

        [HttpGet()]
        public async Task<Models.Emoji> GetAll(string Token)
        {
            return await _emojiService.GetAll(Token);
        }
    }
}
