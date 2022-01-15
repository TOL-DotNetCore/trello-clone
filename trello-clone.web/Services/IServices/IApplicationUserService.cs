using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Entities;

namespace trello_clone.web.Services.IServices
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetUSer(string id);
        Task UploadAvatar(IFormFile file, string userId);
    }

}
