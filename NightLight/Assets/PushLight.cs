using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushLight : MonoBehaviour
{
    public float PushStrenght = 1;
    public float Timer = 5;
    bool PushMe = true;
    // Update is called once per frame
    void Update()
    {
        if (PushMe == true)
        {
            PushMe = false;
            Debug.Log("I PUSHED");
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(PushStrenght, PushStrenght, 0));
            StartCoroutine(PushAgain());
        }
       

    }
    private IEnumerator PushAgain()
    {
        yield return new WaitForSeconds(Timer);
        PushMe = true;
    }
   
}
