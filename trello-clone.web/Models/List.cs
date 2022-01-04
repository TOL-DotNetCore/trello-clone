using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class List
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public double pos { get; set; }
        //public object softLimit { get; set; }
        public string idBoard { get; set; }
        public bool subscribed { get; set; }
    }
}
