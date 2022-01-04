using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Old
    {
        public string name { get; set; }
    }

    public class BoardShortcut
    {
        public string name { get; set; }
        public string id { get; set; }
        public string shortLink { get; set; }
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Data
    {
        public Old old { get; set; }
        public Board board { get; set; }
    }

    public class Limits
    {
    }

    public class Icon
    {
        public string url { get; set; }
    }

    public class AppCreator
    {
        public string id { get; set; }
        public Icon icon { get; set; }
    }

    public class Name
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class MemberCreator
    {
        public string type { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public string text { get; set; }
        public bool activityBlocked { get; set; }
        public string avatarHash { get; set; }
        public string avatarUrl { get; set; }
        public string fullName { get; set; }
        public object idMemberReferrer { get; set; }
        public string initials { get; set; }
        public NonPublic nonPublic { get; set; }
        public bool nonPublicAvailable { get; set; }
    }

    public class Entities
    {
        public Board board { get; set; }
        public Name name { get; set; }
        public MemberCreator memberCreator { get; set; }
    }

    public class Display
    {
        public string translationKey { get; set; }
        public Entities entities { get; set; }
    }

    public class NonPublic
    {
    }

    public class Action
    {
        public string id { get; set; }
        public string idMemberCreator { get; set; }
        public Data data { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public Limits limits { get; set; }
        public AppCreator appCreator { get; set; }
        public Display display { get; set; }
        public MemberCreator memberCreator { get; set; }
    }


}
