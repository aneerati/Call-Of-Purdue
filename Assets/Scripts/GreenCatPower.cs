using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCatPower : MonoBehaviour
{
    PlayerController player;
    Cat catClass;
    
    float time = 10;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        catClass = gameObject.GetComponent<Cat>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0 && catClass.owned)
        {
            player.health += 5;
            time = 10;
            
        }
    }
}
