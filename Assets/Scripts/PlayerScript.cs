using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float playerInput;
    Rigidbody2D body;

    public float paddleSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInput = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        body.velocity = new Vector2(0, playerInput * paddleSpeed);
    }



}

