using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    [Header("Boundary settings")]
    public float boundaryPercent;
    public float easing = 5f;

    private float lBound;
    private float rBound;
    private float dBound;
    private float uBound;
    // Start is called before the first frame update
    void Start()
    {
        lBound = boundaryPercent * Camera.main.pixelWidth;
        rBound = Camera.main.pixelWidth - lBound;
        dBound = (boundaryPercent - 0.05f) * Camera.main.pixelHeight;
        uBound = Camera.main.pixelHeight - dBound;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            Vector3 spriteLoc = Camera.main.WorldToScreenPoint(player.transform.position);

            Vector3 pos = transform.position;

            if(spriteLoc.x < lBound)
            {
                pos.x -= lBound - spriteLoc.x;
            } else if (spriteLoc.x > rBound)
            {
                pos.x += spriteLoc.x - rBound;
            }

            if(spriteLoc.y < dBound)
            {
                pos.y -= dBound - spriteLoc.y;
            } else if(spriteLoc.y > uBound)
            {
                pos.y += spriteLoc.y - uBound;
            }

            pos = Vector3.Lerp(transform.position, pos, easing);

            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
