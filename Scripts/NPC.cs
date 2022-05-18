using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructsNPC;

public interface Interactables
{

    void Interact();
    void CloseInteract();
}
namespace StructsNPC
{
    public enum PositionEnum
    {
        Farmer, Soldier, Lord, King, Merchant, Priest, Commander
    }
    public struct IdentityStruct
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool? Gender { get; set; }//1 for men
        public NPC MarriedTo { get; set; }//null for single
        public Religion Religion { get; set; }
        public PositionEnum? Position { get; set; }
    }
    public struct PersonalitiesStruct
    {
        public float? Religious { get; set; }
        public float? Commercial { get; set; }
        public float? Bureaucrat { get; set; }
        //these three together can't be high
        public float? Ruthless { get; set; }
        public float? Diligence { get; set; }//çalýþkanlýk
        public float? Curiosity { get; set; }
    }
    public struct PredictabilityStruct
    {
        public float? Wisdom { get; set; }
        public float? Boldness { get; set; }
        public float? Madness { get; set; }
    }
    public struct InventoryStruct
    {
        public int? Gold { get; set; }
        public Army personalArmy { get; set; }
        public List<OwnablePlace> OwnedPlaces { get; set; }
        public List<Item> Items { get; set; }
        //supply items
        public int? numberOfSoldiers => personalArmy.TotalNumber();
    }
    public struct SkillsStruct
    {
        public int? Tactics { get; set; }
        public int? MeleeSkill { get; set; }
        public int? ArcherSkill { get; set; }
        public int? MarksmenSkill { get; set; }
        public int? Maneuverability { get; set; }
        public int? Ruling { get; set; }
    }
    
}
public class NPCStructs
{
    public IdentityStruct Identity { get; set; }
    public PersonalitiesStruct Personalities { get; set; }
    public PredictabilityStruct Predictability { get; set; }
    public InventoryStruct Inventory { get; set; }
    public SkillsStruct Skills { get; set; }
}


public class NPC : MonoBehaviour, Interactables
{
    public int ID { get; private set; }
    public NPCStructs NPCStructs { get; private set; }

    public int ApparentPower => 0;//armies, gold, owned places etc avarage of them


    public NPCMemory Memory { get; private set; }
    public NPCLogic Logic { get; private set; }

    public List<RelationWithNPC> Relations;

    private void OnEnable()
    {
        GameManager.HourPassedEvent += LogicUpdateCaller;
    }
    private void OnDisable()
    {
        GameManager.HourPassedEvent -= LogicUpdateCaller;
    }
    private void Awake()
    {
        Logic = new NPCLogic();
        Logic.NPC = this;
        Memory = new NPCMemory();
        NPCStructs = new NPCStructs();

        
        //Debug.Log(System.Runtime.InteropServices.Marshal.SizeOf(NPCStructs.Identity));
    }

    void Update()
    {
        
    }
    public void LogicUpdateCaller()
    {
        Logic.LogicUpdate();
    }

    public void Interact()
    {
        //
    }
    public void CloseInteract()
    {
        //
    }

    /*var a = new EventSpace.Die();
        a.Date = new EventSpace.Date();
        a.Date.Year = 1000;
        a.Date.Month = 1;
        a.Date.Day = 1;
        a.Date.Hour = 1;
        Logic.AddDecisionToPool(a);
        var b = new EventSpace.Die();
        b.Date = new EventSpace.Date();
        b.Date.Year = 1100;
        b.Date.Month = 1;
        b.Date.Day = 1;
        b.Date.Hour = 1;
        Logic.AddDecisionToPool(b);
        var c = new EventSpace.Die();
        c.Date = new EventSpace.Date();
        c.Date.Year = 900;
        c.Date.Month = 1;
        c.Date.Day = 1;
        c.Date.Hour = 1;
        Logic.AddDecisionToPool(c);
        c = new EventSpace.Die();
        c.Date = new EventSpace.Date();
        c.Date.Year = 500;
        c.Date.Month = 1;
        c.Date.Day = 1;
        c.Date.Hour = 1;
        Logic.AddDecisionToPool(c);
        c = new EventSpace.Die();
        c.Date = new EventSpace.Date();
        c.Date.Year = 850;
        c.Date.Month = 1;
        c.Date.Day = 1;
        c.Date.Hour = 1;
        Logic.AddDecisionToPool(c);
        c = new EventSpace.Die();
        c.Date = new EventSpace.Date();
        c.Date.Year = 1050;
        c.Date.Month = 1;
        c.Date.Day = 1;
        c.Date.Hour = 1;
        Logic.AddDecisionToPool(c);
        c = new EventSpace.Die();
        c.Date = new EventSpace.Date();
        c.Date.Year = 700;
        c.Date.Month = 1;
        c.Date.Day = 1;
        c.Date.Hour = 1;
        Logic.AddDecisionToPool(c);
        Logic.SortDecisions();
        foreach (var item in Memory.DecisionPool)
        {
            Debug.Log(item.Date.Year);
        }*/
}
