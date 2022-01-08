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
        public async Task<Models.Card> GetCardById(string cardId, string Token)
        {
            var task = await _cardservice.GetCardAsync(cardId, Token);
            return task;
        }

        [HttpPost("listId={idList}")]
        public async Task<IActionResult> Create([FromBody] Card cardToCreate, string idList, string Token)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var task = await _cardservice.CreateCardAsync(cardToCreate, idList, Token);
            return Ok(task);
        }

        [HttpPut("{cardId}")]
        public async Task<Card> UpdateCard([FromBody] Card cardToUpdate, string cardId, string Token)
        {
            return await _cardservice.UpdateCardAsync(cardToUpdate, cardId, Token);
        }

        [HttpDelete("{cardId}")]
        public async Task DeleteCard(string cardId, string Token)
        {
            await _cardservice.DeleteCardAsync(cardId, Token);

        }

        [HttpGet("{cardId}/actions")]
        public async Task<Models.Action> GetActionOnCard(string cardId, string Token)
        {
            var task = await _cardservice.GetActionOnCard(cardId, Token);
            return task;
        }

        [HttpGet("{cardId}/board")]
        public async Task<Models.Board> GetBoardCardIsOn(string cardId, string Token)
        {
            var task = await _cardservice.GetBoardCardIsOn(cardId, Token);
            return task;
        }

        [HttpGet("{cardId}/checkitems")]
        public async Task<List<Models.CheckItem>> GetChekcItemsOnTheCard(string cardId, string Token)
        {
            var task = await _cardservice.GetCheckItemsOnTheCard(cardId, Token);
            return task;
        }

        [HttpGet("{cardId}/checklists")]
        public async Task<List<Models.Checklist>> GetChekcListsOnTheCard(string cardId, string Token)
        {
            var task = await _cardservice.GetCheckListsOnTheCard(cardId, Token);
            return task;
        }

        [HttpGet("{cardId}/members")]
        public async Task<List<Models.Member>> GetMembersOfCard(string cardId, string Token)
        {
            var task = await _cardservice.GetMembersOfCards(cardId, Token);
            return task;
        }

        // Attachment
        [HttpGet("{cardId}/attachments")]
        public async Task<List<Attachment>> GetAttachmentsOnACard(string cardId, string Token)
        {
            var tasks = await _cardservice.GetAttachmentsOnACard(cardId, Token);
            return tasks;
        }

        [HttpGet("{cardId}/attachments/{attachmentId}")]
        public async Task<Attachment> GetAttachmentsOnACard(string cardId, string attachmentId, string Token)
        {
            var task = await _cardservice.GetAnAttachment(cardId, attachmentId, Token);
            return task;
        }

        [HttpPost("{cardId}/attachments")]
        public async Task<Attachment> CreateAttachment(string cardId, [FromForm] AttachmentCreateRequest request, string Token)
        {
            var task = await _cardservice.CreateAttachment(cardId, request, Token);
            return task;
        }

        [HttpDelete("{cardId}/attachments/{attachmentId}")]
        public async Task DeleteAttachment(string cardId, string attachmentId, string Token)
        {
            await _cardservice.DeleteAttachment(cardId, attachmentId, Token);
        }

        // Comments
        [HttpPost("{cardId}/comments")]
        public async Task<Models.Action> CreateComment(string cardId, string text, string Token)
        {
            var comment = await _cardservice.CreateComment(cardId, text, Token);
            return comment;
        }
    }
}
