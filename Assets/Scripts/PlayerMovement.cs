using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float spawnPos;
    private float spawnY;
    private float spawnDirection;
    public PlayerPlacer placer;
  
    private Rigidbody2D rb;
    private float move;
    private bool isJumping;

    public float speed;
    public float jump;

    public float scale;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        placer = GameObject.FindGameObjectWithTag("Placer").GetComponent<PlayerPlacer>();

        // player spawn
        spawnPos = placer.getPlayerPos();
        spawnDirection = placer.getPlayerDirection();
        spawnY = placer.getPlayerY();
        transform.position = new Vector3(spawnPos, spawnY, 0);
        transform.localScale = new Vector3(spawnDirection, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move == -1)
        {
            transform.localScale = new Vector3(-scale, scale, scale);  
        }
        else if (move == 1)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }

        if (rb.velocity.x != 0 && !isJumping)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(Input.GetButtonDown("Vertical") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
            animator.SetBool("isGrounded", false);
        }
}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isGrounded", true);
        }
    }

    
}

    
