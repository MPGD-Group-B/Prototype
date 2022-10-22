using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{

    [SerializeField] string playerTag = "player";
    [SerializeField] float disappearTime = 3;

    Animator ghostAnim;

    [SerializeField] bool canReset;
    [SerializeField] float resetTime;


    void Start()
    {
        ghostAnim = GetComponent<Animator>();
        ghostAnim.SetFloat("DisappearTime", 1 / disappearTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == playerTag)
        {
            ghostAnim.SetBool("Trigger", true);
        }
    }

    public void TriggerReset()
    {
        if(canReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(resetTime);
        ghostAnim.SetBool("Trigger", false);
    }



}
