using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    void Update()
    {
        Vector3 position = transform.position;
        position[1] = 0.08f;
        transform.position = position;
    }
}
