using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramFunc : MonoBehaviour
{
    public Transform tramTransform;
    public float moveSpeed = 1f;

    public XRButton forwardButton;
    public XRButton backButton;

    private bool isMoving = false;
    private bool isMovingForward = false;
    public Transform playerTransform;
    private bool isMovingBackward = false;

    void Update()
    {
        if (isMoving)
        {
            float direction = isMovingForward ? 1f : -1f;
            tramTransform.position += transform.forward * moveSpeed * direction * Time.deltaTime;
        }
    }

    public void MoveForward()
    {
        if (!isMoving && forwardButton.InPosition())
        {
            isMoving = true;
            isMovingForward = true;
            isMovingBackward = false;

            
            playerTransform.SetParent(tramTransform);
        }
    }

    public void MoveBackward()
    {
        if (!isMoving && backButton.InPosition())
        {
            isMoving = true;
            isMovingForward = false;
            isMovingBackward = true;

            
            playerTransform.SetParent(tramTransform);
        }
    }

    public void StopMoving()
    {
        isMoving = false;
        isMovingForward = false;
        isMovingBackward = false;

        
        playerTransform.SetParent(null);

    }
}
