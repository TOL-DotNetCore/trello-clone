using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class CheckItem
    {
        public string idChecklist { get; set; }
        public string state { get; set; }
        public string idCheckItem { get; set; }
        public string name { get; set; }
        public object nameData { get; set; }
        public int pos { get; set; }
        public object due { get; set; }
        public object idMember { get; set; }
    }
    public class Checklist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string idCard { get; set; }
        public int pos { get; set; }
        public string idBoard { get; set; }
        public List<CheckItem> checkItems { get; set; }
    }
}
