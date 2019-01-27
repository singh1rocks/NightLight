using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidForce : MonoBehaviour
{
    public Rigidbody lidRB;
    public float speed;
    public bool touched = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (touched == true)
        {
            touched = false;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(speed, speed * 2, speed - 3));
        }
    
    }
}
