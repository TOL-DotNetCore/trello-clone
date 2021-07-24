﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{boardId}/cardsduefromdate")]
        public async Task<List<Models.Card>> GetAllCardBetween(string boardId, DateTime start, DateTime end)
        {
            var tasks = await _boardService.GetAllCardBetween(boardId, start.ToUniversalTime(), end.ToUniversalTime());
            return tasks;
        }

        //https://localhost:44395/api/boards/6089796c27952b1ac618b338/weeksumary
        [HttpGet("{boardId}/weeksumary")]
        public async Task<WeekSumary> GetSumaryOfWeek(string boardId)
        {
            var task = await _boardService.GetSumaryOfWeek(boardId);
            return task;
        }

        [HttpGet("{boardId}/unfinishedcurrentday")]
        public async Task<List<Models.Card>> GetAllCardsUnfinished(string boardId)
        {
            var tasks = await _boardService.GetCardsUnfinished(boardId);
            return tasks;
        }

        [HttpGet("{boardId}/unfinished")]
        public async Task<List<Models.Card>> GetAllCardsUnfinished(string boardId, DateTime start, DateTime end)
        {
            var tasks = await _boardService.GetCardsUnfinished(boardId, start, end);
            return tasks;
        }

        [HttpGet("{boardId}/lists")]
        public async Task<List<Models.List>> GetListOnBoard(string boardId)
        {
            var tasks = await _boardService.GetListsOnBoard(boardId);
            return tasks;
        }
    }
}
