using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform background;
    private Transform cam;
    public float parallaxScale = 1f;
    public float smoothing = 1f;

    private Vector2 previousCamPos;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 parallax = new Vector2 ((previousCamPos.x - cam.position.x) * parallaxScale, (previousCamPos.y - cam.position.y) * parallaxScale);
        Vector2 backgroundTargetPos = new Vector2 (background.position.x + parallax.x, background.position.y + parallax.y);
        background.position = Vector2.Lerp(background.position, backgroundTargetPos, smoothing * Time.deltaTime);
        previousCamPos = cam.position;
    }
}
