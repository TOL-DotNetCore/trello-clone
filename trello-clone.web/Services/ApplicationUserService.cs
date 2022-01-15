using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Data;
using trello_clone.web.Entities;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ApplicationUser> GetUSer(string id)
        {
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
