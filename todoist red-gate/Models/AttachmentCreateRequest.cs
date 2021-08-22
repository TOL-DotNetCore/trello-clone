using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class AttachmentCreateRequest
    {
        public string name { get; set; }
        public IFormFile file { get; set; }
    }
}
