using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openthedoor : MonoBehaviour
{
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
                Destroy(gameObject);
            }
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
