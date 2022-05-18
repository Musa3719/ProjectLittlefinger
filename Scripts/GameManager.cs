using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static EventSpace.Date GlobalDate;
    public static List<Religion> AllReligions;

    private List<EventSpace.GlobalEvent> GameDecisionPool;

    public static event Action HourPassedEvent;
    private void Awake()
    {
        GameDecisionPool = new List<EventSpace.GlobalEvent>();

        AllReligions = CreateReligionSamples();

        GlobalDate = new EventSpace.Date();
        GlobalDate.Year = 981;
        GlobalDate.Month = 10;
        GlobalDate.Day = 5;
        GlobalDate.Hour = 10;

    }
    private void OnEnable()
    {
        HourPassedEvent += LogicUpdate;
    }
    private void OnDisable()
    {
        HourPassedEvent -= LogicUpdate;
    }
    private void Update()
    {
        InvokeRepeating("InGameTimeContinue", 50, 50);
    }
    private void InGameTimeContinue()
    {
        HourPassedEvent?.Invoke();

        GlobalDate.Hour += 1;
        if (GlobalDate.Hour >= 24)
        {
            GlobalDate.Hour = 0;
            GlobalDate.Day += 1;
            if (GlobalDate.Day > 30)
            {
                GlobalDate.Day = 1;
                GlobalDate.Month += 1;
                if (GlobalDate.Month > 12)
                {
                    GlobalDate.Month = 1;
                    GlobalDate.Year += 1;
                }
            }
        }
    }
    public void LogicUpdate()
    {
        if (GameDecisionPool.Count > 0)
        {
            GameDecisionPool[0].TryDoEvent();
        }
    }
    private List<Religion> CreateReligionSamples()
    {
        var a = new List<Religion>();
        a.Add(new SampleReligion());
        return a;
    }
}
