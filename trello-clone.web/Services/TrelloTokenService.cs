using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using trello_clone.web.Data;
using trello_clone.web.Entities;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Services
{
    public class TrelloTokenService : ITrelloTokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;
        public TrelloTokenService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetToken()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var trelloToken = (from tk in _db.TrelloTokens
                        where tk.IdentityUser.Id.Equals(userId)
                        select tk).FirstOrDefault();
            if(trelloToken != null)
                return trelloToken.Token;
            return "";
        }

        public void SaveToken(string tlToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var trelloToken = (from tk in _db.TrelloTokens
                               where tk.IdentityUser.Id.Equals(userId)
                               select tk).FirstOrDefault();
            if(trelloToken == null)
            {
                var trelloTokenToCreate = new TrelloToken()
                {
                    IdentityUserId = userId,
                    Token = tlToken
                };

                _db.TrelloTokens.Add(trelloTokenToCreate);
                _db.SaveChanges();
            }
            else
            {
                trelloToken.Token = tlToken;
                _db.TrelloTokens.Update(trelloToken);
                _db.SaveChanges();
            }
        }
    }
}
//test commit
