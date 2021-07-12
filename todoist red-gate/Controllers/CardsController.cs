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

        [HttpGet("{cardId}", Name = "GetCard")]
        public async Task<Models.Card> GetCardById(string cardId)
        {
            var task = await _cardservice.GetCardAsync(cardId);
            return task;
        }

        [HttpPost("idlist={idList}")]
        public async Task<Card> Create([FromBody] Card cardToCreate, string idList)
        {
            return await _cardservice.CreateCardAsync(cardToCreate, idList);    
        }

        [HttpPut("{cardId}")]
        public async Task<Card> UpdateCard([FromBody] Card cardToUpdate, string cardId)
        {
            return await _cardservice.UpdateCardAsync(cardToUpdate, cardId);
        }

        [HttpDelete("{cardId}")]
        public async Task DeleteCard(string cardId)
        {
            await _cardservice.DeleteCardAsync(cardId);

        }

        [HttpGet("{cardId}/actions")]
        public async Task<Models.Action> GetACtionOnCard(string cardId)
        {
            var task = await _cardservice.GetActionOnCard(cardId);
            return task;
        }

        [HttpGet("{cardId}/board")]
        public async Task<Models.Board> GetBoardCardIsOn(string cardId)
        {
            var task = await _cardservice.GetBoardCardIsOn(cardId);
            return task;
        }

        [HttpGet("{cardId}/checkitems")]
        public async Task<List<Models.CheckItem>> GetChekcItemsOnTheCard(string cardId)
        {
            var task = await _cardservice.GetCheckItemsOnTheCard(cardId);
            return task;
        }

        [HttpGet("{cardId}/checklists")]
        public async Task<List<Models.Checklist>> GetChekcListsOnTheCard(string cardId)
        {
            var task = await _cardservice.GetCheckListsOnTheCard(cardId);
            return task;
        }

        [HttpGet("{cardId}/members")]
        public async Task<List<Models.Member>> GetMembersOfCard(string cardId)
        {
            var task = await _cardservice.GetMembersOfCards(cardId);
            return task;
        }
    }
}
