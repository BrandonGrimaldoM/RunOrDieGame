using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpeed : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float runningSpeed = 2.5f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (currentRunningSpeed>runningSpeed)
            {
                currentRunningSpeed = runningSpeed;

            }
            rigidBody.velocity = new Vector2(currentRunningSpeed, rigidBody.velocity.y);

        }
        else
        {
            rigidBody.Sleep();
        }
        
    }

    void Restart()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
        

    }
    public void StartCam()
    {
        
        //retrasa la aparicion de un metodo con invoke
        Invoke("Restart", 0.1f);
    }


}
