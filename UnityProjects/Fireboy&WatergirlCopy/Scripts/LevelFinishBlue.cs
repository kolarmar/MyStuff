using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishBlue : MonoBehaviour
{
    [SerializeField] private Logic logic;
    [SerializeField] private LevelFinishRed levelFinishedRed;
    public bool playerOnFinish = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "BluePlayer")
        {
            playerOnFinish = true;
        }
        
        if (collider.tag == "BluePlayer" && levelFinishedRed.playerOnFinish)
        {
            logic.LevelComplete();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "BluePlayer")
        {
            playerOnFinish = false;
        }
    }
}
