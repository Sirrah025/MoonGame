using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 100f;
    private Rigidbody2D rb;

    private float vertical;
    private float horizontal;
    private Vector3 pos;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            Debug.Log(rb.velocity);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, pos.y);
    }

    private void jump()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
