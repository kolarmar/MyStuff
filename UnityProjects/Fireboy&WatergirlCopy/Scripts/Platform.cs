using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float fallingSpeed;
    [SerializeField] public float maxY;
    [SerializeField] public float minY;
    private bool touchingPlayer;

    private void Update()
    {
        if (gameObject.transform.position.y > minY)
        {
            FallDown();
        }
    }

    private void FallDown()
    {
        if (!touchingPlayer)
        {
            gameObject.transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BluePlayer" || collision.collider.tag == "RedPlayer")
        {
            touchingPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "BluePlayer" || collision.collider.tag == "RedPlayer")
        {
            touchingPlayer = false;
        }
    }
}
