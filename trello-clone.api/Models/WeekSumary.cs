using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoist_red_gate.Models
{
    public class WeekSumary
    {
        public List<Card> listCardCom { get; set; }
        public List<Card> listCardUnf { get; set; }

        public WeekSumary()
        {
            listCardCom = new List<Card>();
            listCardUnf = new List<Card>();
        }
        public WeekSumary(List<Card> listCardCom, List<Card> listCardUnf)
        {
            this.listCardCom = listCardCom;
            this.listCardUnf = listCardUnf;
        }

        public void AddCardComplete(List<Card> a)
        {
            listCardCom.AddRange(a);
        }
        public void AddCardUnfinished(List<Card> a)
        {
            listCardUnf.AddRange(a);
        }
    }
}
