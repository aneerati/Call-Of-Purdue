using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCatPower : MonoBehaviour
{

    PlayerController player;
    Cat catClass;

    private float time = 5;

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
            player.points += 20;
            time = 10;
            
        }

    }
}
