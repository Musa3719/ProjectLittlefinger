using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StructsNPC;

[CreateAssetMenu(menuName = "Scriptables/NPC")]
public class NPCScriptable : ScriptableObject
{
    [Header("Identity")]
    public string Name;
    public int Age;
    public Religion Religion;
    public bool Gender;
    public NPC MarriedTo;
    public PositionEnum Position;
    //public Religion Religion; seperate

    [Space]
    [Header("Personalities")]
    [Space]

    [Range(0f, 1f)]
    public float Religious;
    [Range(0f, 1f)]
    public float Commercial;
    [Range(0f, 1f)]
    public float Bureaucrat;
    //for these three, a number(1 to 2) is seperated among them
    [Range(0f, 1f)]
    public float Ruthless;
    [Range(0f, 1f)]
    public float Diligence;//çalýþkanlýk
    [Range(0f, 1f)]
    public float Curiosity;

    [Space]
    [Header("Predictability")]
    [Space]

    [Range(0f, 1f)]
    public float Wisdom;
    [Range(0f, 1f)]
    public float Boldness;
    [Range(0f, 1f)]
    public float Madness;

    [Space]
    [Header("Inventory")]
    [Space]

    public int Gold;
    //public List<OwnablePlace> OwnedPlaces; seperate
    //public List<Item> Items; seperate
    [Header("Army")]
    public int Spearman;
    public int Swordsman;
    public int Knight;
    public int Archer;
    public int Marksman;
    public int Scout;
    public int Officer; //subay

    [Space]
    [Header("Skills")]
    [Space]

    public int Tactics;
    public int MeleeSkill;
    public int ArcherSkill;
    public int MarksmenSkill;
    public int Maneuverability;
    public int Ruling;
}
