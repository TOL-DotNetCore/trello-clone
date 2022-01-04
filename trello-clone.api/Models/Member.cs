using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class MarketingOptIn
    {
        public bool optedIn { get; set; }
        public DateTime date { get; set; }
    }

    public class MessagesDismissed
    {
        public string _id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public DateTime lastDismissed { get; set; }
    }

    public class Privacy
    {
        public string fullName { get; set; }
        public string avatar { get; set; }
    }

    public class TotalPerMember
    {
        public string status { get; set; }
        public int disableAt { get; set; }
        public int warnAt { get; set; }
    }

    public class Boards
    {
        public TotalPerMember totalPerMember { get; set; }
    }

    public class Orgs
    {
        public TotalPerMember totalPerMember { get; set; }
    }

    public class BioData
    {
        public Emoji emoji { get; set; }
    }


    public class Member
    {
        public string id { get; set; }
        public string aaId { get; set; }
        public bool isAaMastered { get; set; }
        public bool activityBlocked { get; set; }
        public object avatarHash { get; set; }
        public object avatarUrl { get; set; }
        public string bio { get; set; }
        public BioData bioData { get; set; }
        public bool confirmed { get; set; }
        public string fullName { get; set; }
        public string idMemberReferrer { get; set; }
        public List<object> idPremOrgsAdmin { get; set; }
        public string initials { get; set; }
        public string memberType { get; set; }
        public NonPublic nonPublic { get; set; }
        public bool nonPublicAvailable { get; set; }
        public List<object> products { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public object aaBlockSyncUntil { get; set; }
        public object aaEmail { get; set; }
        public object aaEnrolledDate { get; set; }
        public string avatarSource { get; set; }
        public int credentialsRemovedCount { get; set; }
        public object domainClaimed { get; set; }
        public object email { get; set; }
        public object goldSunsetFreeTrialIdOrganization { get; set; }
        public string gravatarHash { get; set; }
        public List<string> idBoards { get; set; }
        public List<string> idOrganizations { get; set; }
        public List<object> idEnterprisesAdmin { get; set; }
        public object loginTypes { get; set; }
        public MarketingOptIn marketingOptIn { get; set; }
        public List<MessagesDismissed> messagesDismissed { get; set; }
        public List<string> oneTimeMessagesDismissed { get; set; }
        public Prefs prefs { get; set; }
        public List<object> trophies { get; set; }
        public object uploadedAvatarHash { get; set; }
        public object uploadedAvatarUrl { get; set; }
        public List<string> premiumFeatures { get; set; }
        public object idEnterprise { get; set; }
        public List<object> idEnterprisesDeactivated { get; set; }
        public string ixUpdate { get; set; }
        public Limits limits { get; set; }
    }


}
