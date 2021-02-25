using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{

    float dirX, moveSpeed = 3f;
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 4f)
            moving = false;
        if (transform.position.x < -4f)
            moving = true;

        if (moving)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
