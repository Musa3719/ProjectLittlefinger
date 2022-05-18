using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NpcCreator : MonoBehaviour
{
    public GameObject FarmerPrefab;
    private void Start()
    {
        CreateFarmers(1, FarmerPrefab);
    }
    private List<GameObject> CreateFarmers(int numberOfNpcForCreation, GameObject prefab)
    {
        string path = "Assets/RandomNames.txt";
        StreamReader reader = new StreamReader(path);
        List<GameObject> Farmers = new List<GameObject>();

        for (int i = 0; i < numberOfNpcForCreation; i++)
        {
            NPC newNpc = Instantiate(prefab).GetComponent<NPC>();
            Farmers.Add(newNpc.gameObject);
            newNpc.NPCStructs.Identity = new StructsNPC.IdentityStruct { Name = GetRandomName(reader), Age = Random.Range(15, 88), Gender= System.Convert.ToBoolean(Random.Range(0,2)),
                Religion= GameManager.AllReligions[Random.Range(0, GameManager.AllReligions.Count)], Position = StructsNPC.PositionEnum.Farmer };

            newNpc.NPCStructs.Personalities = new StructsNPC.PersonalitiesStruct
            {
                Ruthless = Random.Range(0f, 1f),
                Diligence = Random.Range(0f, 1f),
                Curiosity = Random.Range(0f, 1f),
                Bureaucrat = Random.Range(0f, 1f),
                Commercial = Random.Range(0f, 1f),
                Religious = Random.Range(0f, 1f),
            };
            while (newNpc.NPCStructs.Personalities.Bureaucrat + newNpc.NPCStructs.Personalities.Commercial + newNpc.NPCStructs.Personalities.Religious > 1.8f)
            {
                newNpc.NPCStructs.Personalities = new StructsNPC.PersonalitiesStruct
                {
                    Ruthless = newNpc.NPCStructs.Personalities.Ruthless,
                    Diligence = newNpc.NPCStructs.Personalities.Diligence,
                    Curiosity = newNpc.NPCStructs.Personalities.Curiosity,
                    Bureaucrat = newNpc.NPCStructs.Personalities.Bureaucrat - 0.07f,
                    Commercial = newNpc.NPCStructs.Personalities.Commercial - 0.07f,
                    Religious = newNpc.NPCStructs.Personalities.Religious - 0.07f,
                };
            }

            newNpc.NPCStructs.Predictability = new StructsNPC.PredictabilityStruct { Boldness = Random.Range(0f, 1f), Madness = Random.Range(0f, 1f), Wisdom = Random.Range(0f, 1f) };

            newNpc.NPCStructs.Inventory = new StructsNPC.InventoryStruct
            {
                Gold = 10,
                personalArmy = null
            };

            newNpc.NPCStructs.Skills = new StructsNPC.SkillsStruct
            {
                ArcherSkill = Random.Range(0, 100),
                MeleeSkill = Random.Range(0, 100),
                Ruling = Random.Range(0, 100),
                MarksmenSkill = Random.Range(0, 100),
                Maneuverability = Random.Range(0, 100),
                Tactics = Random.Range(0, 100),
            };

        }
        reader.Close();
        return Farmers;
    }
    private string GetRandomName(StreamReader reader)
    {
        string[] lines = reader.ReadToEnd().Split("\n");
        return lines[Random.Range(0, lines.Length)];
    }
}
