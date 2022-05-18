using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField]
    private Vector3 cameraOffset;

    Transform playerTransform;

    void Awake()
    {
        instance = this;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = playerTransform.position + cameraOffset;

        transform.eulerAngles = playerTransform.eulerAngles;
    }
    

    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraOffset;
    }

    public void LookAround()
    {
        float xOffset = -Input.GetAxisRaw("Mouse Y");
        float yOffset = Input.GetAxisRaw("Mouse X");

        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, playerTransform.eulerAngles.y + yOffset, playerTransform.eulerAngles.z);

        transform.eulerAngles = playerTransform.eulerAngles + new Vector3(transform.eulerAngles.x + xOffset, 0f, 0f);
        if(transform.eulerAngles.x > 70 && transform.eulerAngles.x < 290)
        {
            float newX = Mathf.Abs(transform.eulerAngles.x - 70f) < Mathf.Abs(transform.eulerAngles.x - 290) ? 70f : 290f;
            transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
