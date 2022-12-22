using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCatPower : MonoBehaviour
{

    PlayerController player;
    Cat catClass;
    public LayerMask layers;
    Collider2D[] enemiesToDamage;
    float cooldown = 0;
    float timeFrozen = -100;
   

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        catClass = gameObject.GetComponent<Cat>();
    }

    // Update is called once per frame
    void Update()
    {

        timeFrozen += Time.deltaTime;
        cooldown += Time.deltaTime;

        if (cooldown >= 8)
        {
            enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, 4f, layers);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().speed /= 10;
                print(enemiesToDamage[i].GetComponent<Enemy>().speed);
            }
            cooldown = 0;
            timeFrozen = 0;
        }
        else if (timeFrozen >= 3)
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().speed *= 10;
            }
            timeFrozen = -100;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
