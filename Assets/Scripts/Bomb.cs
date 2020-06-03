using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator anim;                          //a holder for our Animator
    public float explodeRadius = 1f;        //a public float for the explosion radius

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player reaches a position past x = 12, spawn bomb
        if (transform.position.x > 12)
        {
            this.gameObject.SetActive(true);
        }
        //otherwise bomb no worky
        else
        {
            this.gameObject.SetActive(false);
        }

        //if we are done exploding
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Bomb_Dead"))
        {
            //destroy all the objects in a radius unless they are tagged Player or hand
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRadius);

            foreach (Collider2D col in colliders)
            {
                if (col.tag != "Player" && col.tag != "hand")
                {
                    Destroy(col.GetComponent<Collider2D>().gameObject);

                }
            }
            Destroy(this.gameObject);

        }
    }

    //Include a script that if the player is too close when the bomb explodes, the game should end
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        //If the object that triggered the event, is tagged player
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }*/
}
