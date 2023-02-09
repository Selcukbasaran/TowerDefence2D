using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public float panSpeed = 3f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector2.up* panSpeed * Time.deltaTime, Space.World); 
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector2.down * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector2.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
