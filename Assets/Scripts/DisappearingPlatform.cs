using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    

    public float timeToTogglePlatform = 2;  //time to toggle platform on and off
    public float currentTime = 0;
    public bool enabled = true;


    void Start()
    {
        
    }

    
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToTogglePlatform)
        {
            currentTime = 0;
            TogglePlatform();

        }

    }


     
    void TogglePlatform()  // function to toggle platform on and off
    {
        enabled = !enabled;
        foreach(Transform child in gameObject.transform)
        {
           if(child.tag != "Player")
            {
                child.gameObject.SetActive(enabled);
            }
        }
    }
}
