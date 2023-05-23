using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenThingy : MonoBehaviour
{
    [SerializeField] private Logic logic;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "BluePlayer" || collider.tag == "RedPlayer")
        {
            logic.GameOver();
        }
    }
}
