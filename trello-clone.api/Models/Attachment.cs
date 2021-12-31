using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{

    public class Attachment
    {
        public string id { get; set; }
        public int bytes { get; set; }
        public DateTime date { get; set; }
        public string edgeColor { get; set; }
        public string idMember { get; set; }
        public bool isUpload { get; set; }
        public string mimeType { get; set; }
        public string name { get; set; }
        public List<Preview> previews { get; set; }
        public string url { get; set; }
        public int pos { get; set; }
        public string fileName { get; set; }
    }
}
