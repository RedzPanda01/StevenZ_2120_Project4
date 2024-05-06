using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    float moveVertical, moveHorizontal;

    [SerializeField] TextMeshProUGUI healthBar;
    [SerializeField] private float moveSpeed = 7f;

    int maxHealth = 100;
    int currentHealth;

    bool dead = false;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        currentHealth = maxHealth;
        healthBar.text = maxHealth.ToString();
    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        if (dead)
        {
            movement = Vector2.zero;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        Hit(10);


    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check to see if collide with enemy
    }

    void Hit(int damage) //Subtracts damage from current health
    {
        currentHealth -= damage;
        healthBar.text = Mathf.Clamp(currentHealth, 0, maxHealth). ToString();

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        dead = true;

        //Write Game Over Code Here
    }
}
