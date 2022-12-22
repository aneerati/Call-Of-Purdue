using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetesHammer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.plasticKnives == 5)
            {
                player.plasticKnives = 0;
                player.damage = 10000;
            }
        }
    }
}
