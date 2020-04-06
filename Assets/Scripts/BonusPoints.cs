using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    private PanCamera powerup;                   // Make container for Heads Up Display
    //public RobotController robot;           // Find the robot object

    private void Start()
    {
        powerup = FindObjectOfType<PanCamera>();
        //robot = FindObjectOfType<RobotController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            powerup.increaseScore(10);
            Destroy(this.gameObject);
        }
    }
}
