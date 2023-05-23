using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishRed : MonoBehaviour
{
    [SerializeField] private Logic logic;
    [SerializeField] private LevelFinishBlue levelFinishedBlue;
    public bool playerOnFinish = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "RedPlayer")
        {
            playerOnFinish = true;
        }

        if (collider.tag == "RedPlayer" && levelFinishedBlue.playerOnFinish)
        {
            logic.LevelComplete();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "RedPlayer")
        {
            playerOnFinish = false;
        }
    }
}
