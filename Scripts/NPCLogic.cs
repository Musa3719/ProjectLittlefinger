using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfoSpace;

public class NPCLogic
{
    public NPC NPC;
    
    public void LogicUpdate()
    {
        if (NPC.Memory.DecisionPool.Count > 0)
        {
            NPC.Memory.DecisionPool[0].TryDoEvent(NPC);
        }
    }
    public void PersonEventHappened(AboutPersonEvent aboutPersonEvent)
    {
        //check info
        //knowledge and characterictic check
        //decision check and date
    }
    public void GlobalEventHappened(AboutGlobalEvent aboutGlobalEvent)
    {
        //check info
        //knowledge and characteristic check
        //decision check and date
    }
    public void SortDecisions()
    {
        NPC.Memory.DecisionPool.Sort((x, y) => EventSpace.Date.Compare(x.Date, y.Date));

    }
    public void AddDecisionToPool(EventSpace.PersonEvent Event)
    {
        NPC.Memory.DecisionPool.Add(Event);
    }
    public void RemoveDecisionFromPool(int Index)
    {
        if (NPC.Memory.DecisionPool[Index] == null) return;
        NPC.Memory.DecisionPool.RemoveAt(Index);
    }
}
