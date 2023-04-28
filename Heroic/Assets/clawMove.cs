using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawMove : MonoBehaviour
{
    public Transform claw;
    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;
    public float clawCloseSpeed = 1f;

    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool clawOpen = true;

    private bool moveForward = false;
    private bool moveBackward = false;
    private void Update()
    {
        if (moveUp)
        {
            claw.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            
        }
        else if (moveDown)
        {
            claw.Translate(Vector3.down * moveSpeed * Time.deltaTime);
           
        }

        if (moveLeft)
        {
            claw.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if (moveRight)
        {
            claw.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
        }

        if (!clawOpen)
        {
            claw.localScale = Vector3.MoveTowards(claw.localScale, Vector3.zero, clawCloseSpeed * Time.deltaTime);
        }
         if (moveBackward)
        {
            claw.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (!clawOpen)
        {
            claw.localScale = Vector3.MoveTowards(claw.localScale, Vector3.zero, clawCloseSpeed * Time.deltaTime);
        }

        if (moveForward)
        {
            claw.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
    }

    public void OnButtonUpPressed()
    {
        moveUp = true;
       
    }

    public void OnButtonUpReleased()
    {
        moveUp = false;
    }

    public void OnButtonDownPressed()
    {
        moveDown = true;
    }

    public void OnButtonDownReleased()
    {
        moveDown = false;
    }

    public void OnButtonLeftPressed()
    {
        moveLeft = true;
    }

    public void OnButtonLeftReleased()
    {
        moveLeft = false;
    }

    public void OnButtonRightPressed()
    {
        moveRight = true;
    }

    public void OnButtonRightReleased()
    {
        moveRight = false;
    }

    public void OnButtonClawPressed()
    {
        clawOpen = !clawOpen;
    }

    public void OnButtonForwardPressed()
    {
        moveForward = true;
    }

    public void OnButtonForwardReleased()
    {
        moveForward = false;
    }

    public void OnButtonBackwardPressed()
    {
        moveBackward = true;
    }

    public void OnButtonBackwardReleased()
    {
        moveBackward = false;
    }

}
