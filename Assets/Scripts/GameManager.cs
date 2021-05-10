using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public int playerScore;
    public int opponentScore;
    public bool _ballAlive;

    //this code lets me call my gamemanager script from other scripts
    // private static GameManager instance;
    // public static GameManager Instance { get { return instance; } }


    public void Start()
    {
        BeginGamePause();

    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {

    }




    // Update is called once per frame
    //void Update()
    //{
    //    if (_ballAlive == true)
    //    {
            
    //        if (gameStarted == true)
    //            {
    //                //Finds gameobject Ball and accesses two variables tracking the score
    //                GameObject ball = GameObject.Find("ballPrefab(Clone)");
    //                BallMovement playerScript = ball.GetComponent<BallMovement>();
    //                playerScore = playerScript._playerScore;
    //                opponentScore = playerScript._opponentScore;

    //        }

    //    }

    //}



    //private void OnGUI()
    //{
    //    //creates a box to display scores via vairable
    //    GUI.Label(new Rect(435, 20, 200, 30), "Score: " + playerScore);

    //    GUI.Label(new Rect(510, 20, 200, 30), "Opponent Score: " + opponentScore);

    //}

    public void BeginGamePause()
    {
        if (gameStarted == false)
        {

            GameObject player = GameObject.Find("Player_Paddle");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.paddleSpeed = 0f;


        }

    }
}

