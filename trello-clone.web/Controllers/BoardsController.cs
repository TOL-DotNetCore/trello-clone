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
    [Authorize]
    public class BoardsController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly IListService _listService;
        private readonly IMemberService _memberService;
        private readonly IOrganizationService _orgService;
        private readonly ITrelloTokenService _trelloTokenService;
        private readonly string trelloToken;
        public BoardsController(IBoardService boardService, IListService listService,
            IOrganizationService orgService,
            IMemberService memberService, ITrelloTokenService trelloTokenService)
        {
            _orgService = orgService;
            _memberService = memberService;
            _trelloTokenService = trelloTokenService;
            _boardService = boardService;
            _listService = listService;
            trelloToken = _trelloTokenService.GetToken();
        }
        public async Task<IActionResult> Read(string id)
        {
            var boardInfo = await _boardService.GetBoard(id, trelloToken);
            ViewBag.BoardInfo = boardInfo;
            ViewBag.BoardId = boardInfo.id;
            ViewBag.Token = trelloToken;
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Index() {
            var me = await _memberService.GetCurrentInfo(trelloToken);

            var allOrg = await _memberService.GetOrganizationsOfMember(me.id, trelloToken);
            ViewBag.Organizations = allOrg;

            var allBoards = new List<List<Board>>();
            foreach (var org in allOrg)
            {
                var allBoardsOfOrg = await _orgService.GetBoardsOfOrg(org.id, trelloToken);
                allBoards.Add(allBoardsOfOrg);
            }
            ViewBag.AllBoards = allBoards;
            return View();
        }

        // Create board
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Create(Board obj)
        {
            await _boardService.Create(obj.name, trelloToken);
            return RedirectToAction("Index");
        }
    }
}
