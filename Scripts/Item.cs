using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public int ItemID { get; protected set; }
    public string Name { get;protected set; }
    public abstract void UseItem();
}
