using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform cameraTransform;

    [SerializeField] float lookSensitivity = 1.0f;
    [SerializeField] float moveSensitivity = 1.0f;
    
    [SerializeField] float sprintMultiplier = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xDelta = Input.GetAxis("Mouse X");  // moving mouse left-right
        float yDelta = Input.GetAxis("Mouse Y");  // moving mouse up-down
        
        playerTransform.Rotate(Vector3.up, lookSensitivity * xDelta * Time.deltaTime);
        cameraTransform.Rotate(Vector3.right, lookSensitivity * -yDelta * Time.deltaTime);
        
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float runSpeed = 1.0f;
        
        if (isSprinting)
        {
            runSpeed = sprintMultiplier;
        }
        
        float xPosDelta = Input.GetAxis("Horizontal");
        float zPosDelta = Input.GetAxis("Vertical");

        Vector3 playerPos = playerTransform.position;
        playerPos += moveSensitivity * runSpeed * xPosDelta * playerTransform.right * Time.deltaTime;
        playerPos += moveSensitivity * runSpeed * zPosDelta * playerTransform.forward * Time.deltaTime;
        playerTransform.position = playerPos;
    }
}
