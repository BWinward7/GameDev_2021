using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    public Transform caster;
    public Vector3 offset = new Vector3(-1,-1,0);
    public GameManager gameManager;

    void Update()
    {
        transform.position = caster.transform.position + offset;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.jumping=true;
        }

    }
 
}
