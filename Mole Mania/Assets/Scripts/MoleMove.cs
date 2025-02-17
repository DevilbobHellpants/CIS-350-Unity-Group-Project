﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Anna Breuker, Ian Connors
 * Mole Mania
 * This script makes the moles move up and down.
 * Might make them do other things once we figure out the timer.
 */

//attach to moles.
public class MoleMove : MonoBehaviour
{
    public float speed;
    public bool isUp;
    private SpawnManager spawnManagerScript;
    private ScoreManager scoreManagerScript;
    public int posIndex = 0;
    public bool isSignMole;

    private float yPos;
    private float xPos;
    private float zPos;
    // Start is called before the first frame update
    void Start()
    {
        isUp = false;
        //Debug.Log("is this script even running");
        StartCoroutine(MoveMoleCoroutine());
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (!isSignMole)
            speed = 5 + scoreManagerScript.score * 5 / 100;
        else
            speed = 5;
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        if (zPos == -4)
            posIndex = 3;
        else if (zPos == 4)
            posIndex = 2;

        else if (zPos == 0)
		{
            if (xPos == 1)
                posIndex = 0;
			else
                posIndex = 1;
		}
        else if (zPos == -8)
		{
            if (xPos == 1)
                posIndex = 4;
            else
                posIndex = 5;
        }
        else if (zPos == 8)
		{
            if (xPos == 1)
                posIndex = 6;
            else
                posIndex = 7;
        }
    }

    IEnumerator MoveMoleCoroutine()
    {
        //add a 1 second delay before first spawning objects
        yield return new WaitForSeconds(1.0f);

        //while (true)
        //{
            MoveMole();

            float randomDelay = Random.Range(15.0f/speed, 25.0f/speed);

            yield return new WaitForSeconds(randomDelay);
        spawnManagerScript.moleHere[posIndex] = false;
        spawnManagerScript.numOfMoles--;
        Destroy(gameObject);
        //}

    }
    void MoveMole()
    {
        if (!isUp)
        {
            transform.position = new Vector3(xPos, yPos + 7, zPos); 
            isUp = true;
        }
        //else 
        //{
        //    transform.position = new Vector3(xPos, yPos, zPos);
        //    isUp = false;
        //}
    }

}
