using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public int idShort { get; set; }
        public string shortLink { get; set; }
    }
}
