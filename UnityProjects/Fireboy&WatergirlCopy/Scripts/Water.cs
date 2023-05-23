using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Logic logic;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "RedPlayer")
        {
            logic.GameOver();
        }
    }
}
