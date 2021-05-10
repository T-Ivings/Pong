using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void Start()
    {
       
    }

    public void PlayerStart()
    {
        GameObject player = GameObject.Find("Player_Paddle");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        playerScript.paddleSpeed = 6f;

        GameObject gameManager = GameObject.Find("Game Manager");
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.gameStarted = true;
        Debug.Log(gameManagerScript.gameStarted);

    }


}
