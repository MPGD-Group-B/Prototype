using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    public bool doubleJump;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doubleJump = true;
            Destroy(gameObject); // destroying the pickup
        }
    }
}
