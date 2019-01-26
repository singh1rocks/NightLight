using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float horizontalSpeed = 4.0f;
    float verticalSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(-v, 0f, 0.00f, Space.Self);
        transform.Rotate(0f, h, 0.00f, Space.World);
        //transform.rotation = new Quaternion(transform.rotation.x - h, transform.rotation.y + v, 0f, transform.rotation.w);
    
    }
}
