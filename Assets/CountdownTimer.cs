using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class CountdownTimer : MonoBehaviour
{
    private Text txtTimer;
    public int second = 120;

    private void Start()
    {
        
        txtTimer = GetComponent<Text>();

    }


    private float nextTime = 1;//

    private void Update()
    {
        //Timer1();
        Timer2();

    }


    private void Timer1()
    {

        if (second == 0)
        {
            CancelInvoke("Timer2");
        }

        if (second >= 0)
        {
            if (second <= 10)
            {
                txtTimer.color = Color.red;
            }

            if (Time.time >= nextTime)
            {
                second--;
                txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);

                nextTime = Time.time + 1;   //
            }
        }
    }

    private float totalTime;
    private void Timer2()
    {
        //

        //
        if (second == 0)
        {
            CancelInvoke("Timer2");
        }

        if (second > 0)
        {
            //Debug.Log("Enter");
            //
            totalTime += Time.deltaTime;
            if (totalTime >= 1)
            {
                if (second <= 10)
                {
                    txtTimer.color = Color.red;
                }
                //Debug.Log("Start");
                second--;
                txtTimer.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
                //Debug.Log("End");
                totalTime = 0;
            }
        }
    }
}

