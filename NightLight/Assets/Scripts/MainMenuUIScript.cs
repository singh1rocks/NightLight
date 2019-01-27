using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class MainMenuUIScript : MonoBehaviour
{
    GameObject baseObject;
    GameObject GameManager;
    Camera refcam;
    Vector3 screenCenter;
    Button StartButton;
    Button CreditsButton;
    RectTransform CreditsRect;
    RectTransform StartRect;

    // Start is called before the first frame update
    void Start()
    {
        refcam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        screenCenter = new Vector3(refcam.scaledPixelWidth * 0.5f, refcam.scaledPixelHeight * 0.5f, 0f);
        GameObject UIText = UIAnnoyances();
        UIText.name = "TitleInfo";

        Canvas screenTextCanvas = UIText.GetComponent<Canvas>();


        StartButton = UIText.AddComponent<Button>();
       // StartButton.addListener(LoadFirstScene);
        StartButton.transform.parent = UIText.transform;

        CreditsButton = UIText.AddComponent<Button>();
        //CreditsButton.addListener(LoadCredits);

        GameObject GoToSleepText = new GameObject();
        //GoToSleepText.transform.parent = screenTextParent.transform;
        //GoToSleepText.name = "SLEEP";
        Text GTSText = GoToSleepText.AddComponent<Text>();
        GTSText.text = "GO TO SLEEP";
        GTSText.color = Color.white;
        GTSText.font = Resources.Load<Font>("Fonts/SourceSansPro-Light");
        GTSText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.07f));
        //GoToSleepText.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
        //GoToSleepText.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.3f, refcam.scaledPixelHeight * 0.1f);
        //GoToSleepText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFirstScene()
    {
        
    }
    void LoadCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    GameObject UIAnnoyances()
    {
        GameObject UITrash = new GameObject();
        UITrash.transform.parent = transform;


        Canvas screenTextCanvas = UITrash.AddComponent<Canvas>();
        screenTextCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        UITrash.AddComponent<CanvasScaler>();
        UITrash.AddComponent<GraphicRaycaster>();

        return UITrash;
    }
}
