using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    public int price = 1000;
    public float priceMultiplier = 1.5f;
    public int healthIncrease = 50;
    public int damageIncrease = 0;
    public bool unlockMagic = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("Ha");
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.points >= price)
            {
                player.points -= price;
                player.maxHealth += healthIncrease;
                player.health += healthIncrease;
                player.damage += damageIncrease;
                price = (int) ((float) price * priceMultiplier);
                if (unlockMagic)
                {
                    player.mageUnlocked = true;
                }
            }
        }
    }
}
