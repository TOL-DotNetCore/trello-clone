using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoist_red_gate.Models;

namespace todoist_red_gate.Services
{
    public interface ICardService
    {
        Task<Card> GetCardAsync(string id, string Token);
        Task<Card> CreateCardAsync(Card task, string listId, string Token);
        Task<Card> UpdateCardAsync(Card task, string idCard, string Token);
        Task DeleteCardAsync(string id, string Token);
        Task<Models.Action> GetActionOnCard(string cardId, string Token);
        Task<Models.Board> GetBoardCardIsOn(string cardId, string Token);
        Task<List<Models.CheckItem>> GetCheckItemsOnTheCard(string cardId, string Token);
        Task<List<Models.Checklist>> GetCheckListsOnTheCard(string cardId, string Token);
        Task<List<Member>> GetMembersOfCards(string cardId, string Token);

        //Attachments
        Task<List<Attachment>> GetAttachmentsOnACard(string cardId, string Token);
        Task<Attachment> GetAnAttachment(string cardId, string attachmentId, string Token);
        Task<Attachment> CreateAttachment(string cardId, AttachmentCreateRequest request, string Token);
        Task DeleteAttachment(string cardId, string attachmentId, string Token);

    }
}

