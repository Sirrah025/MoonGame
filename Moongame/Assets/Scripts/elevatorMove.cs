using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorMove : MonoBehaviour
{

    float diry, moveSpeed = 2f;
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(platWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }

    public IEnumerator platWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (moving)
                moving = false;
            else
                moving = true;
        }
    }
}
