using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Religion
{
    public int ReligionID { get; protected set; }
    public string Name { get; protected set; }
}
public class SampleReligion:Religion
{

}
