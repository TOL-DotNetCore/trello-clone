using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class Trello
    {
        public string unified { get; set; }
        public string name { get; set; }
        public string native { get; set; }
        public string shortName { get; set; }
        public List<string> shortNames { get; set; }
        public string text { get; set; }
        public List<string> texts { get; set; }
        public string category { get; set; }
        public int sheetX { get; set; }
        public int sheetY { get; set; }
        public string tts { get; set; }
        public List<string> keywords { get; set; }
    }

    public class Emoji
    {
        public List<Trello> trello { get; set; }
    }
}
