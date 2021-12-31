using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
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

        [HttpPost("listId={idList}")]
        public async Task<Models.Card> Create([FromBody] Card cardToCreate, string idList)
        {
            var task = await _cardservice.CreateCardAsync(cardToCreate, idList);
            return task;
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

        // Attachment
        [HttpGet("{cardId}/attachments")]
        public async Task<List<Attachment>> GetAttachmentsOnACard(string cardId)
        {
            var tasks = await _cardservice.GetAttachmentsOnACard(cardId);
            return tasks;
        }

        [HttpGet("{cardId}/attachments/{attachmentId}")]
        public async Task<Attachment> GetAttachmentsOnACard(string cardId, string attachmentId)
        {
            var task = await _cardservice.GetAnAttachment(cardId, attachmentId);
            return task;
        }

        [HttpPost("{cardId}/attachments")]
        public async Task<Attachment> CreateAttachment(string cardId, [FromForm] AttachmentCreateRequest request)
        {
            var task = await _cardservice.CreateAttachment(cardId, request);
            return task;
        }

        [HttpDelete("{cardId}/attachments/{attachmentId}")]
        public async Task DeleteAttachment(string cardId, string attachmentId)
        {
            await _cardservice.DeleteAttachment(cardId, attachmentId);
        }
    }
}
