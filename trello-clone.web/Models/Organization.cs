using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class Organization
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public object descData { get; set; }
        public object website { get; set; }
        public object teamType { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public object logoHash { get; set; }
        public object logoUrl { get; set; }
        public List<object> products { get; set; }
        public List<object> powerUps { get; set; }
    }
}
