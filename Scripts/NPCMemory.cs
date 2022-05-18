using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoSpace;
using EventSpace;

public class NPCMemory
{
    public List<PersonEvent> DecisionPool;

    public List<List<AboutPersonStructs>> PersonStructKnowledge { get; private set; }
    public List<List<AboutPersonEvent>> PersonEventKnowledge { get; private set; }
    public List<List<AboutLocation>> LocationKnowledge { get; private set; }
    public List<List<AboutGlobalEvent>> GlobalEventKnowledge { get; private set; }
    public List<List<AboutReligion>> ReligionKnowledge { get; private set; }
    public List<List<AboutNation>> NationKnowledge { get; private set; }
    public List<List<AboutItem>> ItemKnowledge { get; private set; }
    public List<List<Concept>> ConceptKnowledge { get; private set; }
    public NPCMemory()
    {
        DecisionPool = new List<PersonEvent>();

        PersonStructKnowledge = new List<List<AboutPersonStructs>>();
        PersonStructKnowledge.Add(new List<AboutPersonStructs>());

        PersonEventKnowledge = new List<List<AboutPersonEvent>>();
        PersonEventKnowledge.Add(new List<AboutPersonEvent>());

        LocationKnowledge = new List<List<AboutLocation>>();
        LocationKnowledge.Add(new List<AboutLocation>());

        GlobalEventKnowledge = new List<List<AboutGlobalEvent>>();
        GlobalEventKnowledge.Add(new List<AboutGlobalEvent>());

        ReligionKnowledge = new List<List<AboutReligion>>();
        ReligionKnowledge.Add(new List<AboutReligion>());

        NationKnowledge = new List<List<AboutNation>>();
        NationKnowledge.Add(new List<AboutNation>());

        ItemKnowledge = new List<List<AboutItem>>();
        ItemKnowledge.Add(new List<AboutItem>());

        ConceptKnowledge = new List<List<Concept>>();
        ConceptKnowledge.Add(new List<Concept>());
    }
}

namespace InfoSpace
{
    public interface Info
    {
        public NPC HeardFrom { get; }
        public object Identifier { get; }
        public void Gain(NPC NpcSelf);
    }
    public static class InfoMethods
    {
        public static void GainMethod<T, Y>(T SelfKnowledge, Y InfoObject) where Y : Info where T : List<List<Y>>
        {
            if (SelfKnowledge[0][0] == null)
            {
                SelfKnowledge[0].Add(InfoObject);
            }
            else
            {
                bool isAdded = false;
                foreach (var knowledgeList in SelfKnowledge)
                {
                    if (knowledgeList[0].Identifier == InfoObject.Identifier)
                    {
                        knowledgeList.Add(InfoObject);
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded)
                {
                    List<Y> newList = new List<Y>();
                    newList.Add(InfoObject);
                    SelfKnowledge.Add(newList);
                }
            }
        }
    }



    public class AboutPersonStructs : Info
    {
        public NPC npc;
        public NPCStructs structs;

        public object Identifier => npc.ID;


        private NPC heardFrom; 
        public NPC HeardFrom => heardFrom;

        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutPersonStructs>>, AboutPersonStructs>(NpcSelf.Memory.PersonStructKnowledge, this);
        }
        
        
    }
    
    public class AboutPersonEvent: Info
    {
        public NPC npc;
        public EventSpace.PersonEvent Event;

        public object Identifier => Event.EventID;

        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;

        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutPersonEvent>>, AboutPersonEvent>(NpcSelf.Memory.PersonEventKnowledge, this);
        }
    }
    
    public class AboutLocation : Info
    {
        public OwnablePlace Location;
        public object Identifier => Location.LocationID;

        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;

        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutLocation>>, AboutLocation>(NpcSelf.Memory.LocationKnowledge, this);
        }
    }

    public class AboutGlobalEvent : Info
    {
        public EventSpace.GlobalEvent Event;
        public object Identifier => Event.GlobalEventID;

        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;

        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutGlobalEvent>>, AboutGlobalEvent>(NpcSelf.Memory.GlobalEventKnowledge, this);
        }
    }
    public class AboutReligion : Info
    {
        public Religion Religion;
        public object Identifier => Religion.ReligionID;
        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;
        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutReligion>>, AboutReligion>(NpcSelf.Memory.ReligionKnowledge, this);
        }
    }
    public class AboutNation : Info
    {
        public Nation Nation;
        public object Identifier => Nation.NationID;
        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;
        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutNation>>, AboutNation>(NpcSelf.Memory.NationKnowledge, this);
        }
    }
    public class AboutItem : Info
    {
        public Item Item;
        public object Identifier => Item.ItemID;
        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;
        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<AboutItem>>, AboutItem>(NpcSelf.Memory.ItemKnowledge, this);
        }
    }
    public class Concept : Info //like ethics or tactics etc
    {
        private NPC heardFrom;
        public NPC HeardFrom => heardFrom;

        public int ConceptID;
        public object Identifier => ConceptID;

        public void Gain(NPC NpcSelf)
        {
            InfoMethods.GainMethod<List<List<Concept>>, Concept>(NpcSelf.Memory.ConceptKnowledge, this);
        }
    }
}
