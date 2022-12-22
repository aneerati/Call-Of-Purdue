using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isEmpty = false;
    public Sprite openSprite;
    private PlayerController player;
    int award = 0;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isEmpty && player.keys > 0)
        {
            award = Random.Range(1, 3);
            switch (award)
            {
                case 1: player.maxHealth += 10;
                        player.health += 10;
                    break;
                case 2:
                    player.speed += .25f;
                    break;
                case 3:
                    player.points += 100;
                    break;
            }
            isEmpty = true;
            player.keys--;
            gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
        }
    }

}
