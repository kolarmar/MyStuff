using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RedGem : MonoBehaviour
{
    private Logic logic;
    private AudioSource soundPlayer;
    [SerializeField] private int scoreToAdd = 1;

    private void Awake()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        soundPlayer = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedPlayer")
        {
            logic.AddRedScore(scoreToAdd);
            logic.PlayCollectGemSound();
            Destroy(gameObject);
        }
    }
}
