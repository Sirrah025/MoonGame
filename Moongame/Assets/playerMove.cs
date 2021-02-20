using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Movement and Jump")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Components")]
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    public LayerMask groundLayer;

    private float horizontal;

    private bool jump = false;
    private bool onGround = false;
    public float groundDist = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundDist, groundLayer);
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && onGround)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log(rb.velocity);
            jump = false;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    


}