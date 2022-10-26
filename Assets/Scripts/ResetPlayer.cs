using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayer : MonoBehaviour
{
    public Button resetButton;
    public CharacterController player;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = player.transform.position;
        //resetButton.onClick.AddListener(ResetPlayerPos);
    }

    private void Update()
    {
        if (player.transform.position.y <= -20){
            Debug.Log("teleport");
            Debug.Log("old position is" + player.transform.position);
            Debug.Log(player.transform.position.y);
            player.transform.position = originalPos;
            Debug.Log("current position is" + player.transform.position);
        }
    }

    void ResetPlayerPos() {
        Debug.Log("it is pressed");
        player.transform.position = originalPos;
    }
    
    
}
