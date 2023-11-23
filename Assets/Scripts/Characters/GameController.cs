using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    private Rigidbody2D rb2D;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }

        if (collision.CompareTag("CaidaVacio"))
        {
            Die();
        }
    }

    private void Die()
    {
        Respawn();
    }

    private void Respawn()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           GameManager.Instance.PerderVidas();
        }
    }
    private void pierdeVida()
    {
        Debug.Log("Pierde Vida");
    }


}
