using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
     private float spawnPos;
    private float spawnY;
    private float spawnDirection;
    public PlayerPlacer placer;
  
    private Rigidbody2D rb;
    private float move;

    public float speed;
    public float fly;

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

        if (rb.velocity.x != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(Input.GetButtonDown("Vertical"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, fly));
            animator.SetBool("isGrounded", false);
        }
}
}
