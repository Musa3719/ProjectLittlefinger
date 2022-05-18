using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RelationWithNPC
{
    public NPC NPC;
    public float RelationVolume;
    public float CountabilityVolume;
}
public struct RelationWithLocation
{
    public OwnablePlace Location;
    public float RelationVolume;
}
public struct RelationWithNation
{
    public Nation Nation;
    public float RelationVolume;
}
public struct RelationWithReligion
{
    public Religion Religion;
    public float RelationVolume;
}