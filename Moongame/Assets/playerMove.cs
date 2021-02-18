using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = ;
    }
}
