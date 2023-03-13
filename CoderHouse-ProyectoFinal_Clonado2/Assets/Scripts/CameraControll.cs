using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float speedH;
    public float speedV;

    float yaw;
    float pitch;
    public float rotMin, rotMax;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(pitch,0,0.0f);

        player.transform.Rotate(0,yaw,0);
        pitch = Mathf.Clamp(pitch,rotMin,rotMax);

    }
}
