﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanCamera : MonoBehaviour
{
    float ydir = 0f;
    float randy = 0f;
    public GameObject Player;

    //for our GUIText object and our score
    public TextMeshProUGUI gui;
    float playerScore = 0;

    //this function updates our guitext object
    void OnGUI()
    {
        gui.GetComponent<TextMeshProUGUI>().text = "Score: " + ((int)(playerScore * 5)).ToString();
    }

    //this is generic function we can call to increase the score by an amount
    public void increaseScore(int amount)
    {
        playerScore += amount;
    }

    // Update is called once per frame
    void Update()
    {
        //check player exists and then proceed, otherwise we get an error when player dies
        if (Player)
        {
            //if player has passed x position of -1 then start moving camera forward with a randomish Y position
            if (Player.transform.position.x > -1)
            {
                playerScore += Time.deltaTime;          //update our score every tick of the clock
                randy = Random.Range(0f, 100f);

                if (randy < 20)
                {
                    ydir = ydir + 0.005f;
                }
                else if (randy > 20 & randy < 40)
                {
                    ydir = ydir - 0.005f;
                }
                else if (randy > 80)
                {
                    ydir = 0f;
                }
                transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y + ydir,-10);
            }
        }
    }
}