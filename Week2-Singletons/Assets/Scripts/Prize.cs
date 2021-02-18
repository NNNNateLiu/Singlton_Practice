using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isClear)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        transform.position = new Vector2( //teleport to a random location
            Random.Range(-8,8),
            Random.Range(-3,6));

        GameManager.instance.score++; //increase the player's score using the Singleton!
        
        print("Score: " + GameManager.instance.score);
    }
}
