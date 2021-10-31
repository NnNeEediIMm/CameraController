using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform pBodyOrOrientation;
    public float eulerAngle;
    public bool isLocked = false;
    private float xRotattion = 0f;

    void Start()
    {
        if (pBodyOrOrientation == null)
        {
            pBodyOrOrientation = transform.parent;
        }
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.smoothDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.smoothDeltaTime;

        xRotattion -= mouseY;
        xRotattion = Mathf.Clamp(xRotattion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotattion, 0f, eulerAngle);
        pBodyOrOrientation.Rotate(Vector3.up * mouseX);

        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        fixPosition();
    }

    void fixPosition()
    {
        transform.position = pBodyOrOrientation.transform.position;
    }
}
