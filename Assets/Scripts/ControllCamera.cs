using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCamera : MonoBehaviour
{
    public static float mouseSensitivity = 80f;
    public Transform playerbody;
    float xRotation = 0;
    public static bool cameraOn;

    private void Awake()
    {
        cameraOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraOn)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerbody.Rotate(Vector3.up * mouseX);
        }
    }
}
