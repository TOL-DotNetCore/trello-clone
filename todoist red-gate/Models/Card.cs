using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class Card
    {
        public string id { get; set; }
        public List<object> checkItemStates { get; set; }
        public bool closed { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public int dueReminder { get; set; }
        public string idBoard { get; set; }
        public string idList { get; set; }
        public List<object> idMembersVoted { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public List<string> idLabels { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public int pos { get; set; }
        public string shortLink { get; set; }
        public bool isTemplate { get; set; }
        public object cardRole { get; set; }
        public bool dueComplete { get; set; }
        public DateTime due { get; set; }
        public object email { get; set; }
        public string shortUrl { get; set; }
        public object start { get; set; }
        public string url { get; set; }
        public List<string> idMembers { get; set; }
        public List<Label> labels { get; set; }
        public List<object> idChecklists { get; set; }
        public bool subscribed { get; set; }
    }
}
