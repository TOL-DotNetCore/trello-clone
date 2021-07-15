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

        [HttpPost("{nameBoard}")]
        public async Task<Models.Board> CreateBoard(string nameBoard)
        {
            return await _boardService.Create(nameBoard);
        } 

        [HttpGet("{idList}/memberships")]
        public async Task<List<Models.Membership>> GetMemberships(string idList)
        {
            var tasks = await _boardService.GetMemberships(idList);
            return tasks;
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

        [HttpGet("{boardId}/cardsdue")]
        public async Task<List<Models.Card>> GetAllCurentDateCardOfBoard(string boardId)
        {
            var tasks = await _boardService.GetAllCurentDateCardOfBoard(boardId);
            return tasks;
        }

        [HttpGet("{boardId}/cardsdue/start={start}&end={end}")]
        public async Task<List<Models.Card>> GetAllCardBetween(string boardId, string start, string end)
        {
            DateTime startDate = DateTime.ParseExact(start, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            var tasks = await _boardService.GetAllCardBetween(boardId, startDate, endDate);
            return tasks;
        }
    }
}
