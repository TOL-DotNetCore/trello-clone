using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class Cover
    {
        public string idAttachment { get; set; }
        public object color { get; set; }
        public object idUploadedBackground { get; set; }
        public string size { get; set; }
        public string brightness { get; set; }
        public List<Scaled> scaled { get; set; }
        public string edgeColor { get; set; }
        public object idPlugin { get; set; }
    }
}
