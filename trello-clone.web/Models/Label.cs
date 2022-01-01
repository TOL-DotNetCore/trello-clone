using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class Label
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }
}
