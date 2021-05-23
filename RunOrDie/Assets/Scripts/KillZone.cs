using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    Collider2D col;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            
            if (collision.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
                PlayerController controller = collision.GetComponent<PlayerController>();
                controller.Die();
                col.enabled = false;
                
            }
        }
        
        
    }

    public void colActivate()
    {
        col.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
