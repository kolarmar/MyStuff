using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject platform;
    [SerializeField] private float risingSpeed;
    [SerializeField] private Color baseColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LiftPLatform();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = baseColor;
    }

    private void LiftPLatform()
    {
        if (platform.transform.position.y < platform.GetComponent<Platform>().maxY)
        {
            platform.transform.position += Vector3.up * risingSpeed * Time.deltaTime;
        }
    }
}
