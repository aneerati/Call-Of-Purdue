using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 50;
    public Slider healthBar;
    public TextMeshProUGUI statsText;
    public GameObject mageExplosion;
    public LayerMask whatIsEnemies;
    public int points = 0;
    public int keys = 0;
    private float mageCoolDown = 10.0f;
    public bool mageUnlocked = false;
    public int plasticKnives = 0;

    private Rigidbody2D rb;
    private Animator anim;

    private float moveInputX;
    private float moveInputY;
    private float invinciblityTimer = 0.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        if (moveInputX != 0 && moveInputY != 0)
        {
            rb.velocity = new Vector2(moveInputX * speed / Mathf.Sqrt(2), moveInputY * speed / Mathf.Sqrt(2));
        } else {
            rb.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
        }

        Vector2 tempRotation = transform.eulerAngles;
        if (moveInputX < 0) {
            anim.SetBool("PlayerMoving", true);
            tempRotation.y = 180;
        } else if (moveInputX > 0 || moveInputY != 0)
        {
            anim.SetBool("PlayerMoving", true);
            tempRotation.y = 0;
        } else {
            anim.SetBool("PlayerMoving", false);
        }
        transform.eulerAngles = tempRotation;

        if (Input.GetKeyDown(KeyCode.Space) && health > 0)
        {
            anim.SetTrigger("PlayerAttack");
        } else if (Input.GetKeyDown(KeyCode.M) && health > 0 && mageCoolDown <= 0 && mageUnlocked)
        {
            mageExplosion.GetComponent<ParticleSystem>().Play();
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, 3f, whatIsEnemies);
            print(enemiesToDamage.Length);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(250);
            }
            mageCoolDown = 10.0f;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.value = (float) health / maxHealth * 100;

        invinciblityTimer -= Time.deltaTime;
        mageCoolDown -= Time.deltaTime;

        statsText.text = health + " - Health\n" + points + " - Points\n" + keys + " - Keys";
    }

    public void TakeDamage(int damage)
    {
        if (invinciblityTimer <= 0.0)
        {
            health -= damage;
            invinciblityTimer = 2f;

            if (health <= 0)
            {
                anim.SetTrigger("PlayerDies");
            }
        }
    }

    public void DeleteObject()
    {
        gameObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
}