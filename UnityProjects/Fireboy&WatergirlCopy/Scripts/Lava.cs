using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Logic logic;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "BluePlayer")
        {
            logic.GameOver();
        }
    }
}
