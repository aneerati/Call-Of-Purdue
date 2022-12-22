using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 15;
    public float speed = 3f;

    private Transform playerPos;
    public float radius = 7f;
    private bool chasing;

    private PlayerController player;
    private BoxCollider2D enemyHitbox;
    private Animator anim;
    private Vector2 target;
    private Vector2 position;
    private Vector2 startingPos;
    private float stunTimer = 0.0f;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerPos = player.gameObject.transform;
        enemyHitbox = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        startingPos.x = gameObject.transform.position.x;
        startingPos.y = gameObject.transform.position.y;
    }

    void Update()
    {
        if (Vector3.Distance(playerPos.position, startingPos) < radius)
        {
                target = playerPos.position;
                position = gameObject.transform.position;

                float step = speed * Time.deltaTime;

                // move sprite towards the target location
                transform.position = Vector2.MoveTowards(transform.position, target, step);

                Vector2 tempRotation = transform.eulerAngles;
                if (target.x - transform.position.x < 0) {
                    anim.SetBool("SlimeMoving", true);
                    tempRotation.y = 180;
                } else if (target.x - transform.position.x > 0 || target.y - transform.position.y != 0)
                {
                    anim.SetBool("SlimeMoving", true);
                    tempRotation.y = 0;
                } else {
                    anim.SetBool("SlimeMoving", false);
                }
                transform.eulerAngles = tempRotation;
        }

        if (Vector3.Distance(playerPos.position, startingPos) > radius)
        {
            target = startingPos;
            position = gameObject.transform.position;

            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            Vector2 tempRotation = transform.eulerAngles;
            if (target.x - transform.position.x < 0) {
                anim.SetBool("SlimeMoving", true);
                tempRotation.y = 180;
            } else if (target.x - transform.position.x > 0 || target.y - transform.position.y != 0)
            {
                anim.SetBool("SlimeMoving", true);
                tempRotation.y = 0;
            } else {
                anim.SetBool("SlimeMoving", false);
            }
            transform.eulerAngles = tempRotation;
        }

        stunTimer -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && stunTimer <= 0)
        {
            player.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("SlimeHit");
        stunTimer = 1.0f;

        if (health <= 0)
        {
            anim.SetBool("SlimeDies", true);
        }
    }

    public void DeleteObject()
    {
        player.points += Random.Range(25, 76);
        Destroy(gameObject);
    }
}