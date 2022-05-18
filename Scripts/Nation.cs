using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Nation
{
    public int NationID { get; protected set; }
    public string Name { get; protected set; }
    public NPC Ruler { get; protected set; }
    public List<NPC> AllLords { get; protected set; }
    public List<OwnablePlace> AllLocations { get; protected set; }
    public int TotalSoldierCount()
    {
        int count = 0;
        foreach (var item in AllLords)
        {
            count += item.NPCStructs.Inventory.personalArmy.TotalNumber();
        }
        foreach (var item in AllLocations)
        {
            count += item.TotalSoldierCount;
        }
        return count;
    }
    public Religion CommonReligion { get; }
}
