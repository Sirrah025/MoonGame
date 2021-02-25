using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthX, lengthY;
    private Vector2 startPos;
    public GameObject cam;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallax));
        float tempY = (cam.transform.position.y * (1 - parallax));
        float distX = (cam.transform.position.x * parallax);
        float distY = (cam.transform.position.y * parallax);

        transform.position = new Vector3(startPos.x + distX, startPos.y + distY, transform.position.z);

        if (temp > startPos.x + lengthX) startPos.x += lengthX;
        else if (temp < startPos.x - lengthX) startPos.x -= lengthX;

        if (tempY > startPos.y + lengthY) startPos.y += lengthY;
        else if (temp < startPos.y - lengthY) startPos.y -= lengthY;
    }
}
