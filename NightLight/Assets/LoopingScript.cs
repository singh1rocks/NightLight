using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingScript : MonoBehaviour
{
    // Update is called once per frame
    public bool count = true;
    Animation animation;
    public void Start()
    {
        animation = gameObject.GetComponent<Animation>();
        animation["Animation Name"].wrapMode = WrapMode.Loop;
    }
    void Update()
    {
        if (count == true)
        {
            count = false;
           // StartCoroutine(PlayAgain());
        }
        
    }

    
    //public IEnumerator PlayAgain()
    //{
    //    yield return new WaitForSeconds(5f);
    //    gameObject.GetComponent<Animator>().Play("Doll");
    //    yield return new WaitForSeconds(5f);
    //    count = true;
    //}
}
