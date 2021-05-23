using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text score, maxscore;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            
            float myScore = controller.GetScore();
            float myMaxScore = PlayerPrefs.GetFloat("maxscore",0);
            score.text = myScore.ToString("f1");
            maxscore.text = myMaxScore.ToString("f1");
        }
    }
}
