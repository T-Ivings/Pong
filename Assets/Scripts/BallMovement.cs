using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 6f;
    public float bounceSpeed = 6f;
    public int _playerScore;
    public int _opponentScore;
    public int xPos = 0;
    public int yPos = 0;
    public bool ballAlive;
    public Vector3 position = new Vector3(0, 0, 0);


    public void Awake()
    {
        ballAlive = true;

        
       


        float chance = Random.Range(0f, 1f);
        if (chance > 0.5f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * ballSpeed;
        }
        else
        { 
            GetComponent<Rigidbody2D>().velocity = Vector2.left * ballSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        if(col.gameObject.name == "AI_Paddle")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * bounceSpeed;
        }

        if (col.gameObject.name == "Player_Paddle")
        {
            float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * bounceSpeed;
        }

        if (col.gameObject.name == "Wall Right")
        {

            GameObject ball = GameObject.Find("ballPrefab(Clone)");
                _opponentScore++;

            ball.transform.position = new Vector3(0, 0, 0);

        }

        if (col.gameObject.name == "Wall Left")
        {

            GameObject ball = GameObject.Find("ballPrefab(Clone)");
            _playerScore++;

            ball.transform.position = new Vector3(0, 0, 0);

            
        }

    }



    public float HitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight)
    {     // ascii art:
          // ||  1 <- at the top of the racket
          // ||
          // ||  0 <- at the middle of the racket
          // ||
          // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnGUI()
    {
        //creates a box to display scores via vairable
        GUI.Label(new Rect(250, 20, 200, 30), "Player 1 Score: " + _playerScore);

        GUI.Label(new Rect(360, 20, 200, 30), "Player 2 Score: " + _opponentScore);
        
    }

    public void PauseGame()
    {
        //how long game is paused
        StartCoroutine(GamePauser(.5f));

    }
    public IEnumerator GamePauser(float pauseTime)
    {

        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;

    }
}
