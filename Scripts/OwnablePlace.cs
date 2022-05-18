using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OwnablePlace
{
    public int LocationID { get; protected set; }
    public string Name { get; protected set; }
    public string Region { get; protected set; }
    public NPC Owner { get; protected set; }
    public Army LocalArmy { get; protected set; }
    public int TotalPeopleCount => 0;//implement it
    public int TotalSoldierCount => LocalArmy.TotalNumber();
    public List<Item> CommonProducts { get; protected set; }
    public Religion CommonReligion { get; protected set; }
}
public class Village : OwnablePlace
{
    /*public Village(string Name, string Region, NPC Owner, Army LocalArmy, List<Item> CommonProducts, Religion CommonReligion)
    {
        Name = Name;
        egion = Region;
        owner = Owner;
        localArmy = LocalArmy;
        commonProducts = CommonProducts;
        commonReligion = CommonReligion;
    }*/
}