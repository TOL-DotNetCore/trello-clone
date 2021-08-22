using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class Scaled
    {
        public string _id { get; set; }
        public string id { get; set; }
        public bool scaled { get; set; }
        public string url { get; set; }
        public int bytes { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }
}
