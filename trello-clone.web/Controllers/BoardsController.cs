using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using trello_clone.web.Entities;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly ITrelloTokenService _trelloTokenService;
        public BoardsController(IBoardService boardService, ITrelloTokenService trelloTokenService)
        {
            _trelloTokenService = trelloTokenService;
            _boardService = boardService;
        }
        [Authorize]
        public async Task<IActionResult> Read(string id)
        {
            var trelloToken = _trelloTokenService.GetToken();
            var boardInfo = await _boardService.GetBoard(id, trelloToken);
            ViewBag.BoardInfo = boardInfo;

            var listsOfBoard = await _boardService.GetListsOfBoard(id, trelloToken);
            ViewBag.ListsOfBoard = listsOfBoard;
            return View();
        }
    }
}
