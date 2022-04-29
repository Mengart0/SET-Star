using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinedMov : MonoBehaviour
{
    public GameObject LeftArm;
    public GameObject RightArm;

    private void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            LeftArmUp(-50);
        }

        if (Input.GetKeyUp("g"))
        {
            LeftArmUp(50);
        }

        if (Input.GetKeyDown("h"))
        {
            RightArmUp(50);
        }
    }

    public void LeftArmUp(float angle)
    {
        LeftArm.transform.Rotate(angle,0,0);
    }
    public void RightArmUp(float angle)
    {
        RightArm.transform.Rotate(angle, 0, 0);
    }
}
