using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    Animator animator;

    public bool groundedCam = false;

    public PlayerMovement PMovement;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cameraChange();
        }
    }

    void cameraChange()
    {
        if (groundedCam == false)
        {
            animator.Play("MainCam");
            PMovement.enabled = true;
        }
        else
        {
            animator.Play("ZoomCam");
            PMovement.enabled = false;
        }

        groundedCam = !groundedCam;
    }
}
