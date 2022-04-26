using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float moveSensitivity = 1.0f;
    [SerializeField] private float lookSensitivity = 1.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xDelta = Input.GetAxis("Mouse X"); // moving mouse left-right
        float yDelta = Input.GetAxis("Mouse Y"); // moving mouse up-down

        playerTransform.Rotate(Vector3.up, lookSensitivity *  xDelta * Time.deltaTime);
        cameraTransform.Rotate(Vector3.right, lookSensitivity * -yDelta * Time.deltaTime);

        float xPosDelta = Input.GetAxis("Horizontal");
        float zPosDelta = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float runSpeed = 1.0f;

        if (isSprinting)
        {
            runSpeed = sprintMultiplier;
        }

        Vector3 playerPos = playerTransform.position;
        playerPos += moveSensitivity * xPosDelta * runSpeed * playerTransform.right * Time.deltaTime;
        playerPos += moveSensitivity * zPosDelta *  runSpeed * playerTransform.forward * Time.deltaTime;
        playerTransform.position = playerPos;

        
        //playerTransform.forward
        // vector3 inputVector = new Vector3(xPosDelta, 0, zPosDelta);
        // playerTransform.position += 

    }
}
