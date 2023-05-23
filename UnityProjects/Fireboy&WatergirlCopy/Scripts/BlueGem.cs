using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{
    private Logic logic;
    [SerializeField] private int scoreToAdd = 1;

    private void Awake()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BluePlayer")
        {
            logic.AddBlueScore(scoreToAdd);
            logic.PlayCollectGemSound();
            Destroy(gameObject);
        }
    }
}
