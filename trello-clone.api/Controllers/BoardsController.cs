using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;
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
        public async Task<Models.Board> CreateBoard(string nameBoard, string Token)
        {
            return await _boardService.Create(nameBoard, Token);
        }

        [HttpGet("{idList}/memberships")]
        public async Task<List<Models.Membership>> GetMemberships(string idList, string Token)
        {
            var tasks = await _boardService.GetMemberships(idList, Token);
            return tasks;
        }

        [HttpGet("{id}")]
        public async Task<Models.Board> Get(string id = "5d6e2a55d1759a59f7dc902d", string Token="")
        {
            var tasks = await _boardService.Get(id, Token);
            return tasks;
        }

        [HttpPut("{id}")]
        public async Task<Models.Board> Update([FromBody] Models.Board boardToUpdate, string id, string Token)
        {
            return await _boardService.Update(id, boardToUpdate, Token);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id, string Token)
        {
            await _boardService.Delete(id, Token);
        }

        

        [HttpGet("{boardId}/cardsdue")]
        public async Task<List<Models.Card>> GetAllCurentDateCardOfBoard(string boardId, string Token)
        {
            var tasks = await _boardService.GetAllCurentDateCardOfBoard(boardId, Token);
            return tasks;
        }

        [HttpGet("{boardId}/cardsduefromdate")]
        public async Task<List<Models.Card>> GetAllCardBetween(string boardId, DateTime start, DateTime end, string Token)
        {
            var tasks = await _boardService.GetAllCardBetween(boardId, start.ToUniversalTime(), end.ToUniversalTime(), Token);
            return tasks;
        }

        //https://localhost:44395/api/boards/6089796c27952b1ac618b338/weeksumary
        [HttpGet("{boardId}/weeksumary")]
        public async Task<WeekSumary> GetSumaryOfWeek(string boardId, string Token)
        {
            var task = await _boardService.GetSumaryOfWeek(boardId, Token);
            return task;
        }

        [HttpGet("{boardId}/unfinishedcurrentday")]
        public async Task<List<Models.Card>> GetAllCardsUnfinished(string boardId, string Token)
        {
            var tasks = await _boardService.GetCardsUnfinished(boardId, Token);
            return tasks;
        }

        [HttpGet("{boardId}/unfinished")]
        public async Task<List<Models.Card>> GetAllCardsUnfinished(string boardId, DateTime start, DateTime end, string Token)
        {
            var tasks = await _boardService.GetCardsUnfinished(boardId, start, end, Token);
            return tasks;
        }

        [HttpGet("{boardId}/lists")]
        public async Task<List<Models.List>> GetListOnBoard(string boardId, string Token)
        {
            var tasks = await _boardService.GetListsOnBoard(boardId, Token);
            return tasks;
        }
    }
}
