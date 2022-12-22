using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.keys++;
            Destroy(gameObject);
            
        }
    }
}
