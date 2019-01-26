using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerThing : MonoBehaviour
{
    public float timerMax = 600f;
    public float timerCurrent = 305f;
    Camera refcam;
    GameObject UITimer;
    public float textTimer = 1f;
    public float textTimerCurrent = 1f;
    public bool isTextActive = false;
    public Vector3 screenCenter;
    public GameObject GoToSleepText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        refcam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        UITimer = new GameObject();
        UITimer.transform.parent = transform;
        drawUITimer(timerCurrent);
        screenCenter = new Vector3(refcam.scaledPixelWidth * 0.5f, refcam.scaledPixelHeight * 0.5f, 0f);
        GameObject screenTextParent = new GameObject();
        screenTextParent.name = "GoToSleep";
		screenTextParent.transform.parent = transform;
        screenTextParent.AddComponent<Canvas>();

        Canvas screenTextCanvas = screenTextParent.GetComponent<Canvas>();
        screenTextCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        screenTextParent.AddComponent<CanvasScaler>();
        screenTextParent.AddComponent<GraphicRaycaster>();
        
        GoToSleepText = new GameObject();
        GoToSleepText.transform.parent = screenTextParent.transform;
        GoToSleepText.name = "SLEEP";
        Text GTSText = GoToSleepText.AddComponent<Text>();
        GTSText.text = "GO TO SLEEP";
        GTSText.color = Color.white;
        GTSText.font = Resources.Load<Font>("Fonts/SourceSansPro-Light");
        GTSText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.07f));
        GoToSleepText.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
        GoToSleepText.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.3f, refcam.scaledPixelHeight * 0.1f);
        GoToSleepText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerCurrent <= 300f)
        {
            if(refcam.fieldOfView < 160f)
            {
                refcam.fieldOfView += Time.deltaTime * 3.0f;
            }
            if(refcam.fieldOfView > 80f)
            {
                if(textTimerCurrent <= 0f)
                {
                    isTextActive = !isTextActive;
                    GoToSleepText.SetActive(isTextActive);
                    textTimerCurrent = textTimer;
                }
                else
                {
                    textTimerCurrent -= Time.deltaTime;
                }
            }
        }

        timerCurrent -= Time.deltaTime;
    }

    public GameObject MakeUITimer()
    {
        GameObject Timer = new GameObject();
        //do some things

        return Timer;
    }

    public void drawUITimer(float width)
    {

    }
}
