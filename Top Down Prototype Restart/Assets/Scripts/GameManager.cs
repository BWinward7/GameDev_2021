using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isDoorLocked;
    public bool jumping;
    public GameObject shadow;
    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isDoorLocked = true;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasKey && !isDoorLocked)
        {
            print("You exit out the door into another room!");
        }
        if(jumping)
        {
            shadow.GetComponent<Renderer>().enabled = true;
            print("Jump!");
        }
        else
        {
            shadow.GetComponent<Renderer>().enabled = false;
        }
    }
}
