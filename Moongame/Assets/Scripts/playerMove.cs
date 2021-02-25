using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Movement and Jump")]
    public float speed = 6f;
    private float jumpForce = 7f;

    [Header("Components")]
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public float groundDist = 0.6f;

    private float horizontal;
    private Vector3 pos;

    private ParticleSystem ps;
    private Vector3 psRot;

    private bool jump = false;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        psRot = ps.shape.rotation;
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
        pos = transform.position;
        if (jump)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log(rb.velocity);
            jump = false;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        GameManager.Instance.increaseScore(transform.position);
        if (pos != transform.position)
        {
            if(horizontal >= 0)
            {
                psRot.y = -99;
            }
            else if(horizontal <= 0)
            {
                psRot.y = 99;
            }
            ps.Play();
        }
        else
        {
            ps.Pause();
        }
    }

    void OnCollisionEnter2D(Collision2D plat)
    {
        if (plat.gameObject.name.Equals("Alien Ship Platform"))
            this.transform.parent = plat.transform;
    }

    void OnCollisionExit2D(Collision2D plat)
    {
        if (plat.gameObject.name.Equals("Alien Ship Platform"))
            this.transform.parent = null;
    }


}