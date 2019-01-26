using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMessage : MonoBehaviour { 

    public Text message;

    private bool initTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("shhhh");
                message.text = "test";
            }
        }
    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
