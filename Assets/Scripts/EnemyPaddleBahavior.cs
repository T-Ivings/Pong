using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleBahavior : MonoBehaviour
{
    Transform paddle;


    void Start()
    {

            //paddle = GameObject.Find("ballPrefab(Clone)").transform; //paddle finds balls movements 
        

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, paddle.position.y, transform.position.z); //follows balls position to a T

    }

    void FixedUpdate()
    {
        
    }


}
