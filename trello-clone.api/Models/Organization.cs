using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class EnterpriseJoinRequest
    {
    }
    public class Organization
    {
        public string id { get; set; }
        public string creationMethod { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public DescData descData { get; set; }
        public object website { get; set; }
        public List<object> promotions { get; set; }
        public EnterpriseJoinRequest enterpriseJoinRequest { get; set; }
        public object standardVariation { get; set; }
        public string teamType { get; set; }
        public string desc { get; set; }
        public string idMemberCreator { get; set; }
        public bool invited { get; set; }
        public List<object> invitations { get; set; }
        public Prefs prefs { get; set; }
        public List<object> powerUps { get; set; }
        public List<object> products { get; set; }
        public string url { get; set; }
        public string logoHash { get; set; }
        public string logoUrl { get; set; }
        public List<string> premiumFeatures { get; set; }
        public string ixUpdate { get; set; }
        public object idEnterprise { get; set; }
        public object availableLicenseCount { get; set; }
        public object maximumLicenseCount { get; set; }
        public Limits limits { get; set; }
        public List<Membership> memberships { get; set; }
        public List<object> credits { get; set; }
        public int billableMemberCount { get; set; }
        public int billableCollaboratorCount { get; set; }
        public int activeBillableMemberCount { get; set; }
        public List<string> idBoards { get; set; }
    }
}
