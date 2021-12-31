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
        public async Task<Models.Board> GetBoard(string listId)
        {
            var tasks = await _listService.GetBoardAListIsOn(listId);
            return tasks;
        }

        [HttpGet("{listId}", Name = "GetList")]
        public async Task<Models.List> GetListById(string listId)
        {
            var task = await _listService.GetListAsync(listId);
            return task;
        }

        [HttpGet("{listId}/cards")]
        public async Task<List<Models.Card>> GetCards(string listId)
        {
            var tasks = await _listService.GetCardsInAList(listId);
            return tasks;
        }

        [HttpPost("{listName}&{idBoard}")]
        public async Task<Models.List> CreateList(string listName, string idBoard)
        {
            return await _listService.CreateListAsync(listName, idBoard);
        }

        [HttpPut("{listId}")]
        public async Task<Models.List> UpdateList([FromBody] Models.List listToUpdate, string listId)
        {
            return await _listService.UpdateListAsync(listToUpdate, listId);
        }

        [HttpPut("{listId}/archive")]
        public async Task ArchiveList(string listId)
        {
            await _listService.ArchiveAsync(listId);
        }

    }
}
