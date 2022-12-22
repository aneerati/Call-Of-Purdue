using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float speed = 7f;
    public Transform playerPos;
    public float chaseLength = 50f;
    public bool chasing;
    private Vector2 target;
    private Vector2 position;
    private Vector2 startingPos;
    private Animator anim;
    public bool owned = false;
    public CatBought catBought;
    private PlayerController player;


    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        anim = gameObject.GetComponent<Animator>();
        catBought.hasBoughtCat = false;
    }

    void Start()
    {
        startingPos.x = gameObject.transform.position.x;
        startingPos.y = gameObject.transform.position.y;
    }

    void Update()
    {
        if (!owned)
        {
            anim.SetBool("moving", false);
        }else
        {
            Vector2 tempRotation = transform.eulerAngles;
            if (target.x - transform.position.x > 0)
            {
                anim.SetBool("moving", true);
                tempRotation.y = 180;
            }
            else if (target.x - transform.position.x < 0 || target.y - transform.position.y != 0)
            {
                anim.SetBool("moving", true);
                tempRotation.y = 0;
            }
            else
            {
                anim.SetBool("moving", false);
            }
            transform.eulerAngles = tempRotation;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player.points >= 1000 && catBought.hasBoughtCat != true)
        {
            player.points = player.points - 1000;
            owned = true;
            catBought.hasBoughtCat = true;
        }
    }

    public void FixedUpdate()
    {
        if (owned) {

            Vector3.Distance(playerPos.position, startingPos);

            target.x = playerPos.position.x + 1;
            target.y = playerPos.position.y + 1;
            position = gameObject.transform.position;

            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, target, step);

        }
    }

}
