using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class Badges
    {
        public AttachmentsByType attachmentsByType { get; set; }
        public bool location { get; set; }
        public int votes { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }
        public string fogbugz { get; set; }
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public object checkItemsEarliestDue { get; set; }
        public int comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public object due { get; set; }
        public bool dueComplete { get; set; }
        public object start { get; set; }
    }
}
