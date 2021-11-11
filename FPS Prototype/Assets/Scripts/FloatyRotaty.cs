using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyRotaty : MonoBehaviour
{
    public float spinSpeed = 0.0f;
    public float bobSpeed = 0.0f;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(spinSpeed,0,0);
        spinSpeed += 1;
    }
}
