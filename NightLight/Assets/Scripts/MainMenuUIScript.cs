using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MainMenuUIScript : MonoBehaviour
{
    GameObject baseObject;
    GameObject GameManager;
    Camera refcam;
    Vector3 screenCenter;
    Button StartButton;
    Button CreditsButton;
    Button ExitButton;
    RectTransform CreditsRect;
    RectTransform StartRect;
    GameObject Startt;
    GameObject Credits;
    GameObject Exittt;
    GameObject StartTextHighlight;
    GameObject CreditsTextHighlight;
    GameObject ExitTextHighlight;
    GameObject CreditsObjectReference;
    
    // Start is called before the first frame update
    void Start()
    {
        refcam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        screenCenter = new Vector3(refcam.scaledPixelWidth * 0.5f, refcam.scaledPixelHeight * 0.5f, 0f);
        GameObject UIText = UIAnnoyances();
        UIText.name = "TitleInfo";

        Canvas screenTextCanvas = UIText.GetComponent<Canvas>();
        GameObject Background = new GameObject();
        Background.transform.parent = UIText.transform;
        Image refImage = Background.AddComponent<Image>();
        refImage.sprite = Resources.Load<Sprite>("Sprites/bg1");
        refImage.type = Image.Type.Sliced;
        Background.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth, refcam.scaledPixelHeight);
        Background.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);

        SpriteState buttonSprites = new SpriteState();
        buttonSprites.highlightedSprite = Resources.Load<Sprite>("Sprites/ButtonSelected");
        buttonSprites.pressedSprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");

        GameObject StartParent = new GameObject();
        Image startImage = StartParent.AddComponent<Image>();
        startImage.sprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");
        startImage.type = Image.Type.Sliced;
        startImage.preserveAspect = true;
        StartButton = StartParent.AddComponent<Button>();
        StartParent.name = "StartButton";
        StartButton.onClick.AddListener(LoadFirstScene);
        Startt = StartParent;

        StartParent.transform.parent = Background.transform;
        StartButton.transition = Button.Transition.SpriteSwap;
        StartButton.spriteState = buttonSprites;
        StartParent.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.20f, refcam.scaledPixelHeight * 0.12f);
        StartParent.GetComponent<RectTransform>().localPosition = new Vector3(0f, refcam.scaledPixelHeight * -0.05f, 0f);


        GameObject CreditsParent = new GameObject();
        Credits = CreditsParent;
        CreditsParent.name = "Credits";
        CreditsParent.transform.parent = Background.transform;
        Image CreditsImage = CreditsParent.AddComponent<Image>();
        CreditsImage.sprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");
        CreditsImage.type = Image.Type.Sliced;
        CreditsImage.preserveAspect = true;
        CreditsButton = CreditsParent.AddComponent<Button>();
        CreditsButton.onClick.AddListener(LoadCredits);
        CreditsButton.transition = Button.Transition.SpriteSwap;
        CreditsButton.spriteState = buttonSprites;
        CreditsParent.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.20f, refcam.scaledPixelHeight * 0.12f);
        CreditsParent.GetComponent<RectTransform>().localPosition = new Vector3(0f, refcam.scaledPixelHeight * -0.21f, 0f);


        GameObject ExitParent = new GameObject();
        ExitParent.transform.parent = Background.transform;
        ExitParent.name = "Exit";
        Exittt = ExitParent;

        Image ExitImage = ExitParent.AddComponent<Image>();
        ExitImage.sprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");
        ExitImage.type = Image.Type.Sliced;
        ExitImage.preserveAspect = true;
        ExitButton = ExitParent.AddComponent<Button>();
        ExitButton.onClick.AddListener(Exit);
        ExitButton.transition = Button.Transition.SpriteSwap;
        ExitButton.spriteState = buttonSprites;
        ExitParent.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.20f, refcam.scaledPixelHeight * 0.12f);
        ExitParent.GetComponent<RectTransform>().localPosition = new Vector3(0f, refcam.scaledPixelHeight * -0.37f, 0f);

        for(int i=0;i<6;i++)
        {
            GameObject ButtonText = new GameObject();
            Text BText = ButtonText.AddComponent<Text>();
            BText.font = Resources.Load<Font>("Fonts/SourceSansPro-Light");
            //BText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.07f));
            BText.alignment = TextAnchor.MiddleCenter;
            RectTransform buttonRect = ButtonText.GetComponent<RectTransform>();

            if(i%2 == 0)
            {
                BText.color = Color.white;
                if(i/2 == 0)
                {
                    ButtonText.transform.parent = StartParent.transform;
                    BText.text = "Start";

                }
                else if(i/2 == 1)
                {
                    ButtonText.transform.parent = CreditsParent.transform;
                    BText.text = "Credits";
                }
                else if(i/2 == 2)
                {
                    ButtonText.transform.parent = ExitParent.transform;
                    BText.text = "Exit";
                }
                BText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.06f));
            }
            else if(i%2 == 1)
            {
                BText.color = Color.black;
                if(i/2 == 0)
                {
                    ButtonText.transform.parent = StartParent.transform;
                    BText.text = "Start";
                    StartTextHighlight = ButtonText;
                    ButtonText.SetActive(false);
                }
                else if(i/2 == 1)
                {
                    ButtonText.transform.parent = CreditsParent.transform;
                    BText.text = "Credits";
                    CreditsTextHighlight = ButtonText;
                    ButtonText.SetActive(false);
                }
                else if(i/2 == 2)
                {
                    ButtonText.transform.parent = ExitParent.transform;
                    BText.text = "Exit";
                    ExitTextHighlight = ButtonText;
                    ButtonText.SetActive(false);
                }
                BText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.05f));
            }
            buttonRect.localPosition = new Vector3(0f, 0f, 0f);
            buttonRect.sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.125f, refcam.scaledPixelHeight * 0.12f);
        }

        GameObject TitleImage = new GameObject();
        TitleImage.transform.parent = UIText.transform;
        Image logo = TitleImage.AddComponent<Image>();
        logo.sprite = Resources.Load<Sprite>("Sprites/titleImage");
        logo.preserveAspect = true;
        logo.type = Image.Type.Simple;
        RectTransform logoRect = TitleImage.GetComponent<RectTransform>();
        logoRect.sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.25f, refcam.scaledPixelWidth * 0.25f);
        logoRect.localPosition = new Vector3(0f, refcam.scaledPixelHeight * 0.3f, 0f);

        GameObject TitleText = new GameObject();
        TitleText.transform.parent = UIText.transform;
        Text TText = TitleText.AddComponent<Text>();
        TText.font = Resources.Load<Font>("Fonts/BebasNeue Bold");
        TText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.23f));
        TText.color = Color.white;
        TText.text = "DAY DREAM";
        TText.alignment = TextAnchor.MiddleCenter;
        TitleText.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.5f, refcam.scaledPixelHeight * 0.3f); 
        TitleText.GetComponent<RectTransform>().localPosition = new Vector3(0f,refcam.scaledPixelHeight * 0.08f,0f);
        //setActiveButton(false, false, false);

        GameObject CopyrightInfo = new GameObject();
        CopyrightInfo.transform.parent = UIText.transform;
        Text CText = CopyrightInfo.AddComponent<Text>();
        CText.font = Resources.Load<Font>("Fonts/SourceSansPro-Regular");
        CText.text = "© 2019 Team Night Light\nMade for EAE Global Game Jam 2019.";
        CText.fontSize = Convert.ToInt32(Math.Floor(refcam.scaledPixelHeight * 0.03f));
        CopyrightInfo.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth * 0.5f, refcam.scaledPixelHeight * 0.15f); 
        CopyrightInfo.GetComponent<RectTransform>().localPosition = new Vector3(refcam.scaledPixelWidth * -.25f,refcam.scaledPixelHeight * -0.45f,0f);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void setActiveButton(bool v1, bool v2, bool v3)
    {
        StartTextHighlight.SetActive(v1);
        CreditsTextHighlight.SetActive(v2);
        ExitTextHighlight.SetActive(v3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene("Day1");
    }
    void LoadCredits()
    {
        SpriteState buttonSprites = new SpriteState();
        buttonSprites.highlightedSprite = Resources.Load<Sprite>("Sprites/ButtonSelected");
        buttonSprites.pressedSprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");
        GameObject CreditsObject = UIAnnoyances();
        CreditsObjectReference = CreditsObject;
        
        
        Canvas screenTextCanvas = CreditsObject.GetComponent<Canvas>();
        GameObject Background = new GameObject();
        Background.transform.parent = CreditsObject.transform;
        Image refImage = Background.AddComponent<Image>();
        refImage.sprite = Resources.Load<Sprite>("Sprites/bg1");
        refImage.type = Image.Type.Simple;
        Background.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth, refcam.scaledPixelHeight);
        Background.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
        
        GameObject Background2 = new GameObject();
        Background.transform.parent = CreditsObject.transform;
        Image refImage2 = Background.AddComponent<Image>();
        refImage2.sprite = Resources.Load<Sprite>("Sprites/CREDITSS");
        refImage2.type = Image.Type.Simple;
        refImage2.preserveAspect = true;
        Background2.GetComponent<RectTransform>().sizeDelta = new Vector2(refcam.scaledPixelWidth, refcam.scaledPixelHeight);
        Background2.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);

        GameObject BackButton = new GameObject();
        Image BBImage = BackButton.AddComponent<Image>();
        BBImage.sprite = Resources.Load<Sprite>("Sprites/ButtonNotSelected");



    }

    public GameObject UIAnnoyances()
    {
        GameObject UITrash = new GameObject();
        UITrash.transform.parent = transform;


        Canvas screenTextCanvas = UITrash.AddComponent<Canvas>();
        screenTextCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        UITrash.AddComponent<CanvasScaler>();
        UITrash.AddComponent<GraphicRaycaster>();

        return UITrash;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.selectedObject == StartButton )
        {
            setActiveButton(true, false, false);
        }
        else if(eventData.selectedObject == CreditsButton)
        {
            setActiveButton(false, true, false);
        }
        else if(eventData.selectedObject == ExitButton)
        {
            setActiveButton(false, false, true);
        }
        else
        {
            //setActiveButton(false, false, false);
        }
    }
}
