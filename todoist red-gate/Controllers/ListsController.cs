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
        [HttpGet()]
        public async Task<List<Models.List>> GetAllList()
        {
            var tasks = await _listService.GetAllListssAsync();
            return tasks;
        }

        [HttpGet("{listId}", Name = "GetList")]
        public async Task<Models.List> GetListById(string listId)
        {
            var task = await _listService.GetListAsync(listId);
            return task;
        }

        [HttpPost()]
        public async Task<Models.List> CreateList([FromBody] Models.List listToCreate)
        {
            return await _listService.CreateListAsync(listToCreate);
        }

        [HttpPut("{listId}")]
        public async Task<Models.List> UpdateList([FromBody] Models.List listToUpdate, string listId)
        {
            return await _listService.UpdateListAsync(listToUpdate, listId);
        }

        [HttpDelete("{listId}")]
        public async Task DeleteList(string listId)
        {
            await _listService.DeleteListAsync(listId);

        }

    }
}
