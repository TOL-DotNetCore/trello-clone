using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class Membership
    {
        public string id { get; set; }
        public string idMember { get; set; }
        public string memberType { get; set; }
        public bool unconfirmed { get; set; }
        public bool deactivated { get; set; }
    }
}
