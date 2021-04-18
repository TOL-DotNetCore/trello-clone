using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;
using todoist_red_gate.Services;
using todoist_red_gate.Services.TrelloServices.TrelloServices;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        ICardService _cardservice;
        public CardsController(ICardService cardservice)
        {
            _cardservice = cardservice;
        }
        [HttpGet("{listId}")]
        public async Task<List<Models.Card>> GetAllCardOfList(string listId)
        {
            var tasks = await _cardservice.GetAllCardsOfListAsync(listId);
            return tasks;
        }

        [HttpGet("{cardID}", Name = "GetCard")]
        public async Task<Models.Card> GetCardById(string id)
        {
            var task = await _cardservice.GetCardAsync(id);
            return task;
        }

        [HttpPost()]
        public async Task<Card> Create_Todo([FromForm] Card cardToCreate, string idList)
        {
            return await _cardservice.CreateCardAsync(cardToCreate, idList);
        }

        [HttpPut("{cardId}")]
        public async Task<Card> UpdateCard([FromForm] Card cardToUpdate, string cardId)
        {
            return await _cardservice.UpdateCardAsync(cardToUpdate, cardId);
        }

        [HttpDelete("{cardId}")]
        public async Task Delete_Todo(string cardId)
        {
            await _cardservice.DeleteCardAsync(cardId);

        }

    }
}
