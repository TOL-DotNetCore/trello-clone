using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private IBoardService _boardService;
        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("{id}")]
        public async Task<Models.Board> Get(string id)
        {
            var tasks = await _boardService.Get(id);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Board> Update([FromBody] Models.Board boardToUpdate, string id)
        {
            return await _boardService.Update(id, boardToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _boardService.Delete(id);
        }
    }
}
