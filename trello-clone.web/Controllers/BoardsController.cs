using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using trello_clone.web.Entities;
using trello_clone.web.Models;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly IListService _listService;
        private readonly ITrelloTokenService _trelloTokenService;
        public BoardsController(IBoardService boardService, IListService listService, ITrelloTokenService trelloTokenService)
        {
            _trelloTokenService = trelloTokenService;
            _boardService = boardService;
            _listService = listService;
        }
        [Authorize]
        public async Task<IActionResult> Read(string id)
        {
            var trelloToken = _trelloTokenService.GetToken();
            var boardInfo = await _boardService.GetBoard(id, trelloToken);
            ViewBag.BoardInfo = boardInfo;

            var listsOfBoard = await _boardService.GetListsOfBoard(id, trelloToken);
            ViewBag.ListsOfBoard = listsOfBoard;

            List<List<Card>> lstCards = new List<List<Card>>();
            foreach(var item in listsOfBoard) {
                var cardsOfList = await _listService.GetCardsOfList(item.id, trelloToken);
                lstCards.Add(cardsOfList);
            }
            ViewBag.LstCards = lstCards;
            
            return View();
        }
    }
}
