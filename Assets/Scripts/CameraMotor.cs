﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;


    private float transation;
    private float animationDuration;
    private Vector3 animationOffset;
    void Start()
    {
        transation = 0f;
        animationDuration = 3.0f;
        animationOffset = new Vector3(0, 5, 5);


        lookAt = GameObject.FindGameObjectWithTag("Player").transform;

        startOffset = transform.position - lookAt.position;

    }



    void Update()
    {

        if(gameObject.tag != "MainCamera")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        moveVector = lookAt.position + startOffset;

        if (gameObject.tag == "MainCamera")
        {
            moveVector.x = 0;



            moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        }
         

        if(transation > 1)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transation);
            transation += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }


    }
}
