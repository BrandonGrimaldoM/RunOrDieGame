using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables del movimiento del personaje
    public float jumpForce = 6f;
    Rigidbody2D rigidBody;
    Animator animator;
    public float runningSpeed = 6f;


    const string STATE_ALIVE = "IsAlive";
    const string STATE_GAME = "StartGame";
    const string STATE_ON_THE_GROUND = "IsOnTheGround";
    Vector3 startPosition;

    
    //suelo
    public LayerMask groundMask;
    // Start is called before the first frame update


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {


        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_GAME, false);
        startPosition = this.transform.position;
    }

    public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_GAME, true);
        //retrasa la aparicion de un metodo con invoke
        Invoke("RestartPosition", 0.1f); 
    }

    void RestartPosition()
    {
        this.transform.position = startPosition;
        this.rigidBody.velocity = Vector2.zero;
        this.rigidBody.velocity = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
       //Debug.DrawRay(this.transform.position, Vector2.down * 1.16f, Color.green);

        if (Input.GetButtonDown("Jump"))
        {
            Jump(false);
        }
        
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
    }

    void FixedUpdate()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
        else
        {
            rigidBody.Sleep();
        }
        
    }

    void Jump(bool super)
    {
        
        if (IsTouchingTheGround())
        {
            GetComponent<AudioSource>().Play();
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(
            /*desde donde estoy*/this.transform.position,
            /*mando un rayo hacia abajo*/Vector2.down,
            /*centimetros*/ 1.16f,
            /*detecto la mascara*/groundMask))
        {
            
            return true;
        }
        else
        {
            
            return false;
        }
    }

    public void Die() {
        
        
        float travelledDistance = GetScore();
        float previosMaxDistance = PlayerPrefs.GetFloat("maxscore",0f);
        if(travelledDistance > previosMaxDistance)
        {
            PlayerPrefs.SetFloat("maxscore",travelledDistance);
        }
        this.animator.SetBool(STATE_ALIVE, false);
        GameManager.sharedInstance.GameOver();
        rigidBody.Sleep();
    }

    
    public float GetScore()
    {
        return this.transform.position.x - startPosition.x;
    }
}

