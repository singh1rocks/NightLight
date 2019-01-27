using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text Box1;
    public Text Box2;
    public Text Box3;
    public GameObject CombDoor;

    [SerializeField]
    private string Password = "656";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            IncreaseParentValue(Box1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            IncreaseParentValue(Box2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            IncreaseParentValue(Box3);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Box1.text + Box2.text + Box3.text == Password)
            {
                CombDoor.GetComponent<KitchenDoorScript>().OpenCombDoor();
                gameObject.SetActive(false);
            }
            else
                GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>().DisplayText("I don't think it's correct...");
        }

    }
    public void IncreaseParentValue(Text box)
    {
        int password = Convert.ToInt32(box.text);
        if (password == 9)
            password = 0;
        else
            password++;
        box.text = password.ToString();
    }
    public void DecreaseParentValue(Text box)
    {
        int password = Convert.ToInt32(box.text);
        if (password == 0)
            password = 9;
        else
            password--;
        box.text = password.ToString();
    }
}
