using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army
{
    //ilerde geliþtir
    public int Spearman { get; private set; }
    public int Swordsman { get; private set; }
    public int Knight { get; private set; }
    public int Archer { get; private set; }
    public int Marksman { get; private set; }
    public int Scout { get; private set; }
    public int Officer { get; private set; } //subay

    public int TotalNumber()
    {
        return Spearman + Swordsman + Knight + Archer + Marksman + Scout + Officer;
    }
}
