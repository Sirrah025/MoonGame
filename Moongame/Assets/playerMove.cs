using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    private float vertical;
    private float horizontal;
    private Vector3 pos;

    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
