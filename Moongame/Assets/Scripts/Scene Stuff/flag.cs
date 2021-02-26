using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour {

    GameManager gm;
    public int nextLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
            GameManager.Instance.LoadNextLevel(nextLevel);
            //gm.LoadNextLevel(nextLevel);
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
