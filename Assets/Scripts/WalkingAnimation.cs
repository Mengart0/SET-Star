using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    private Vector3 lastpos;

    Animator anim;

    public CameraControls CControlScript;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        CControlScript = GameObject.Find("CM StateDrivenCamera1").GetComponent<CameraControls>();
    }

    void Update()
    {
        //Don't know why but this isn't working -Efe
        if (CControlScript.groundedCam)
        {
            if (this.transform.position != lastpos)
            {
                anim.Play("Walking");
            }
            else
            {
                anim.Play("Idle");
            }
            lastpos = this.transform.position;
        }
    }
}
