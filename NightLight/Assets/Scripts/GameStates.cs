//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//public class GameStates : MonoBehaviour
//{
//    public enum EngineStates
//    {
//        PRELOAD,
//        SPLASH,
//        TITLE,
//        DAY,
//        NIGHT,
//        DREAM,
//        GOODEND,
//        BADEND,
//        CULTEND,
//        GAMEOVER,
//        CREDITS
//    }
//    public enum DayStates
//    {
//        DAY1,
//        DAY2,
//        DAY3,
//        DAY4,
//        DAY5
//    }
//    public DayStates currentDay;
//    public EngineStates currentState;
//    public int healthMax = 10;
//    public int healthCurrent = 10;
//    public int warmthMax = 10;
//    public int warmthCurrent = 10;
//    public float dayTimer = 600f;
//    public float timerCurrent = 600f;
//    public bool matchesObtained = false;
//    public bool key2Obtained = false;
//    public bool key3Obtained = false;
//    public bool key4Obtained = false;
//    public bool key5Obtained = false;
//    public bool key6Obtained = false;
//    public bool key7Obtained = false;
//    public bool key8Obtained = false;
//    public bool key9Obtained = false;
//    public bool key10Obtained = false;
//    public float respectsTimer = 1f;
//    public bool respectActive = false;
//    public GameObject respectReference;
//    public int currentNumberOfConsecutiveDreams = 0;

//    public bool scene1Loaded = false;
//    public bool scene2Loaded = false;
//    public bool scene3Loaded = false;
//    public bool scene4Loaded = false;
//    public bool scene5Loaded = false;
//    public bool scene6Loaded = false;
//    public bool scene7Loaded = false;
//    public bool scene8Loaded = false;
//    public bool timerStarted = false;
//    public bool isNight = false;
//    public void Awake()
//    {
//        currentState = EngineStates.PRELOAD;
//        currentDay = DayStates.DAY1;
//        DontDestroyOnLoad(this.gameObject);
//    }
//    public void Update()
//    {
//        switch(currentState)
//        {
//            case EngineStates.PRELOAD:
//            currentState = EngineStates.SPLASH;
//            break;
//            case EngineStates.SPLASH:
//            //add a logo here and then
//            //load the title scene. Have something in that trigger EngineStates.Day
//            currentState = EngineStates.TITLE;
//            break;
//            case EngineStates.TITLE:
//            currentState = EngineStates.DAY;
//            break;
//            case EngineStates.DAY:
//                switch(currentDay)
//                {
//                    if(!timerStarted)
//                    {
//                        //do something here
//                    }
//                    //load different states in each of these switches.
//                    case DayStates.DAY1:
//                    if(!scene1Loaded)
//                    {
//                        SceneManager.LoadScene("Chris_test");
//                        scene1Loaded = true;
//                    }
//                    break;
//                    case DayStates.DAY2:
//                    break;
//                    case DayStates.DAY3:
//                    break;
//                    case DayStates.DAY4:
//                    break;
//                    case DayStates.DAY5:
//                    break;
//                }
//            break;
//            case EngineStates.NIGHT:
//            break;
//            case EngineStates.DREAM:
//                switch(currentDay)
//                {
//                    case DayStates.DAY1:
//                    break;
//                    case DayStates.DAY2:
//                    break;
//                    case DayStates.DAY3:
//                    break;
//                    case DayStates.DAY4:
//                    break;
//                    case DayStates.DAY5:
//                    break;
//                }
//            break;
//            case EngineStates.GOODEND:
//            break;
//            case EngineStates.BADEND:
//            break;
//            case EngineStates.CULTEND:
//            break;
//            case EngineStates.GAMEOVER:
//            break;
//            case EngineStates.CREDITS:
//            break;
//        }
//        if(Input.GetKeyDown(KeyCode.F))
//        {
//            if(!respectActive)
//            {
//                GameObject Respects = new GameObject();
//                Respects.transform.parent = transform;
//                Respects.AddComponent<Canvas>();
//                Respects.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
//                Respects.AddComponent<CanvasScaler>();
//                Respects.AddComponent<GraphicRaycaster>();
//                GameObject RespectText = new GameObject();
//                RespectText.transform.parent = Respects.transform;
//                Text RespectTextt = RespectText.AddComponent<Text>();
//                RespectTextt.font = Resources.Load<Font>("Fonts/SourceSansPro-Regular");
//                RespectTextt.color = Color.white;
//                RespectTextt.text = "You pay your respects to the fallen.";
//                RespectTextt.fontSize = Convert.ToInt32(Math.Floor(Camera.main.scaledPixelHeight * 0.05f));
//                RectTransform rect = RespectText.GetComponent<RectTransform>();
//                rect.localPosition = new Vector3(0f,Camera.main.scaledPixelHeight * 0.4f,0f);
//                rect.sizeDelta = new Vector2(Camera.main.scaledPixelWidth * 0.5f, Camera.main.scaledPixelHeight * 0.1f);

//                respectReference = Respects;
//                respectActive = true;
//            }
//        }
//        if(respectActive)
//        {
//            PayRespects(respectReference);
//        }
//    }

//    private void PayRespects(GameObject respeeeect)
//    {

//       if(respectsTimer > 0)
//       {

//       }
//       else if(respectsTimer <= 0)
//       {
//            Destroy(respeeeect);
//            respectActive = false;
//            respectsTimer = 1f;

//       }
//       respectsTimer -= Time.deltaTime;
//    }
//}