using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSpace;

namespace EventSpace
{
    public struct Date
    {
        public int Hour;
        public int Day;
        public int Month;
        public int Year;
        public static int Compare(Date x, Date y)
        {
            return x > y ? 1 : x == y ? 0 : -1;
        }
        public static bool operator ==(Date x, Date y)
        {
            return x.Hour == y.Hour && x.Day == y.Day && x.Month == y.Month && x.Year == y.Year;
        }
        public static bool operator !=(Date x, Date y)
        {
            return !(x == y);
        }
        public static bool operator >(Date x, Date y)
        {
            if (x.Year != y.Year)
            {
                return x.Year > y.Year ? true : false;
            }
            else if (x.Month != y.Month)
            {
                return x.Month > y.Month ? true : false;
            }
            else if (x.Day != y.Day)
            {
                return x.Day > y.Day ? true : false;
            }
            else if(x.Hour!=y.Hour)
            {
                return x.Hour > y.Hour ? true : false;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Date x, Date y)
        {
            return !(x == y) && !(x > y);
        }

        
    }
    public abstract class Event
    {
        public int EventID;
        public bool IsHappened;
        public Date Date; //null means unknown

        protected abstract void DoEvent();
    }


    #region PersonEvents
    public abstract class PersonEvent : Event
    {
        public NPC Person { get; protected set; }

        public bool TryDoEvent(NPC SelfPerson)
        {
            if (!IsHappened && SelfPerson == Person && Date == GameManager.GlobalDate)
            {
                DoEvent();
                IsHappened = true;
                return true;
            }
            return false;
        }
        
    }
    public class Die : PersonEvent
    {
        //maybe something
        protected override void DoEvent()
        {
            
        }
    }
    public class Move : PersonEvent
    {
        public OwnablePlace MoveLocation;
        protected override void DoEvent()
        {
            
        }
    }
    public class RelationChangedNPC : PersonEvent
    {
        public NPC RelationChangedWith;
        public float RelationChangedVolume;
        public float CountabilityChangedVolume;
        protected override void DoEvent()
        {

        }
    }
    public class RelationChangedNation : PersonEvent
    {
        public Nation RelationChangedWith;
        public float RelationChangedVolume;
        protected override void DoEvent()
        {

        }
    }
    public class RelationChangedReligion : PersonEvent
    {
        public Religion RelationChangedWith;
        public float RelationChangedVolume;
        protected override void DoEvent()
        {

        }
    }
    public class RelationChangedLocation : PersonEvent
    {
        public OwnablePlace RelationChangedWith;
        public float RelationChangedVolume;
        protected override void DoEvent()
        {

        }
    }
    public class ShareInfo : PersonEvent
    {
        public NPC ShareTo;
        public InfoSpace.Info Info; 
        protected override void DoEvent()
        {
            
        }
    }
    public class AskForInfo : PersonEvent
    {
        public NPC AskFrom;
        public InfoSpace.Info Info;
        protected override void DoEvent()
        {
            
        }
    }
    public class GainGold : PersonEvent
    {
        public int GoldGained;
        protected override void DoEvent()
        {
            
        }
    }
    public class LoseGold : PersonEvent
    {
        public int GoldLost;
        protected override void DoEvent()
        {
            
        }
    }
    public class DeclareWar : PersonEvent
    {
        public Nation DeclaredNation;
        protected override void DoEvent()
        {
            
        }
    }
    public class GainSoldiers : PersonEvent
    {
        public Army GainedArmy;
        protected override void DoEvent()
        {
            
        }
    }
    public class EscapeCaptivity : PersonEvent
    {
        public OwnablePlace EscapedFromLocation;
        public NPC EscapedFromNPC;
        protected override void DoEvent()
        {
            
        }
    }
    public class EnterBattle : PersonEvent
    {
        //battle class maybe
        protected override void DoEvent()
        {
            
        }
    }
    public class ChallangeSomeone : PersonEvent
    {
        public NPC ChallangedNPC;
        //challange way?
        protected override void DoEvent()
        {
            
        }
    }
    public class Pillage : PersonEvent
    {
        public OwnablePlace PillageLocation;
        protected override void DoEvent()
        {
            
        }
    }
    public class GetMarried : PersonEvent
    {
        public NPC WillMarriedTo;
        protected override void DoEvent()
        {
            
        }
    }
    public class ChangeReligion : PersonEvent
    {
        public Religion newReligion;
        protected override void DoEvent()
        {
            
        }
    }
    public class ChangeNation : PersonEvent
    {
        public Nation newNation;
        protected override void DoEvent()
        {

        }
    }
    public class TakeControlOverLocation : PersonEvent
    {
        public OwnablePlace Location;
        protected override void DoEvent()
        {
            
        }
    }
    public class ChangeCharacteristic : PersonEvent
    {
        protected override void DoEvent()
        {
            
        }
    }
    public class GainItem : PersonEvent
    {
        public Item GainedItem;
        protected override void DoEvent()
        {
            
        }
    }
    public class AgeUp : PersonEvent
    {
        protected override void DoEvent()
        {
            Person.NPCStructs.Identity = new StructsNPC.IdentityStruct
            {
                Age = Person.NPCStructs.Identity.Age + 1,
                Gender = Person.NPCStructs.Identity.Gender,
                MarriedTo = Person.NPCStructs.Identity.MarriedTo,
                Name = Person.NPCStructs.Identity.Name,
                Position = Person.NPCStructs.Identity.Position,
                Religion = Person.NPCStructs.Identity.Religion
            };
        }
    }
    #endregion

    #region GlobalEvents
    public abstract class GlobalEvent : Event
    {
        protected bool isThisTheSource { get; set; }
        public int GlobalEventID { get; protected set; }
        public string EventName { get; protected set; }
        public OwnablePlace Location { get; protected set; }
        public string Region { get; protected set; }

        public bool TryDoEvent()
        {
            if (isThisTheSource && GameManager.GlobalDate == Date)
            {
                DoEvent();
                IsHappened = true;
                return true;
            }
            return false;
        }
    }
    public class A : GlobalEvent
    {
        protected override void DoEvent()
        {
            
        }
    }
    #endregion
}
