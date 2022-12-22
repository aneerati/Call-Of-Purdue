using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetesKeys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().plasticKnives += 1;
            print("Yo");
            Destroy(gameObject);
        }
    }
}
