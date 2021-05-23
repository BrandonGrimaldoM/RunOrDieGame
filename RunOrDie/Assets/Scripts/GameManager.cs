using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enumerado de stados del juego
public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    PlayerController controller;
    GroundSpeed groundjiji;
    KillZone kill;
    
    void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        groundjiji = GameObject.Find("GroundSpeedCam").GetComponent<GroundSpeed>();
        kill = GameObject.Find("Aplanadora").GetComponent<KillZone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
       
        
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {

        }else if(newGameState == GameState.inGame)
        {
            LevelManager.sharedInstance.RemoveAllLevelBolcks();
            Invoke("ReloadLevel", 0.1f);
            groundjiji.StartCam();
            controller.StartGame();
            
            MenuManager.sharedInstance.HideMainMenu();
            MenuManager.sharedInstance.ShowInfoMenu();
            Invoke("ResetCol", 1f);


        }
        else if (newGameState == GameState.gameOver)
        {
            
            MenuManager.sharedInstance.HideInfoMenu();
            MenuManager.sharedInstance.ShowMainMenu();
        }
        this.currentGameState = newGameState;
    }

    private void ResetCol()
    {
        kill.colActivate();
    }

    void ReloadLevel()
    {
        LevelManager.sharedInstance.GenerateInitialBlocks();
    }

    

    
}
