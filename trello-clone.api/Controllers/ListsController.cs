using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Services;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private IListService _listService;
        public ListsController(IListService listService)
        {
            _listService = listService;
        }
        [HttpGet("{listId}/board")]
        public async Task<Models.Board> GetBoard(string listId, string Token)
        {
            var tasks = await _listService.GetBoardAListIsOn(listId, Token);
            return tasks;
        }

        [HttpGet("{listId}", Name = "GetList")]
        public async Task<Models.List> GetListById(string listId, string Token)
        {
            var task = await _listService.GetListAsync(listId, Token);
            return task;
        }

        [HttpGet("{listId}/cards")]
        public async Task<List<Models.Card>> GetCards(string listId="5d7a5dfdba15a47397b982c9", string Token="38d8a9fd92b16d19eace2b414dca84cc86a98f1b4d47e8d06ed86a81eb3edfe0")
        {
            var tasks = await _listService.GetCardsInAList(listId, Token);
            return tasks;
        }

        [HttpPost("{listName}&{idBoard}")]
        public async Task<Models.List> CreateList(string listName, string idBoard, string Token)
        {
            return await _listService.CreateListAsync(listName, idBoard, Token);
        }

        [HttpPut("{listId}")]
        public async Task<Models.List> UpdateList([FromBody] Models.List listToUpdate, string listId, string Token)
        {
            return await _listService.UpdateListAsync(listToUpdate, listId, Token);
        }

        [HttpPut("{listId}/archive")]
        public async Task ArchiveList(string listId, string Token)
        {
            await _listService.ArchiveAsync(listId, Token);
        }

    }
}
