using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;
        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }
        [Authorize]
        public async Task<IActionResult> Read(string id)
        
        {
            var boardInfo = await _boardService.GetBoard(id);
            var listsOfBoard = await _boardService.GetListsOfBoard(id);
            ViewBag.BoardInfo = boardInfo;
            ViewBag.ListsOfBoard = listsOfBoard;
            return View();
        }
    }
}
