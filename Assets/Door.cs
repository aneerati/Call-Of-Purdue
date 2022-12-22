using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public int price = 1000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.points >= price)
            {
                player.points -= price;
                gameObject.SetActive(false);
            }
        }
    }

}
