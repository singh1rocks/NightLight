using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public enum EngineStates
    {
        PRELOAD,
        SPLASH,
        TITLE,
        DAY,
        NIGHT,
        DREAM,
        GOODEND,
        BADEND,
        CULTEND,
        GAMEOVER,
        CREDITS
    }
    public enum DayStates
    {
        DAY1,
        DAY2,
        DAY3,
        DAY4,
        DAY5
    }
    public DayStates currentDay;
    public EngineStates currentState;
    public int healthMax = 10;
    public int healthCurrent = 10;
    public int warmthMax = 10;
    public int warmthCurrent = 10;
    public float dayTimer = 600f;
    public float timerCurrent = 600f;
    public bool key1Obtained = false;
    public bool key2Obtained = false;
    public bool key3Obtained = false;
    public bool key4Obtained = false;
    public bool key5Obtained = false;
    public bool key6Obtained = false;
    public bool key7Obtained = false;
    public bool key8Obtained = false;
    public bool key9Obtained = false;
    public bool key10Obtained = false;

    public void Start()
    {
        currentState = EngineStates.PRELOAD;
        currentDay = DayStates.DAY1;
    }
    public void Update()
    {
        switch(currentState)
        {
            case EngineStates.PRELOAD:
            break;
            case EngineStates.SPLASH:
            break;
            case EngineStates.TITLE:
            break;
            case EngineStates.DAY:
                switch(currentDay)
                {
                    case DayStates.DAY1:
                    break;
                    case DayStates.DAY2:
                    break;
                    case DayStates.DAY3:
                    break;
                    case DayStates.DAY4:
                    break;
                    case DayStates.DAY5:
                    break;
                }
            break;
            case EngineStates.NIGHT:
            break;
            case EngineStates.DREAM:
                switch(currentDay)
                {
                    case DayStates.DAY1:
                    break;
                    case DayStates.DAY2:
                    break;
                    case DayStates.DAY3:
                    break;
                    case DayStates.DAY4:
                    break;
                    case DayStates.DAY5:
                    break;
                }
            break;
            case EngineStates.GOODEND:
            break;
            case EngineStates.BADEND:
            break;
            case EngineStates.CULTEND:
            break;
            case EngineStates.GAMEOVER:
            break;
            case EngineStates.CREDITS:
            break;
        }

    }
}