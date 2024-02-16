using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4.0f;
    public Player player;

    void Start()
    {
      //  player = GameObject.Find("Player").GetComponent<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        //  move enemy down 4 meters for second.
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        // if the bottom of screen
        // respawn at top with a new random x position.
        
        if (transform.position.y <  -5f)
        {
            float randomX = Random.RandomRange(-8f, 8f);
            transform.position = new Vector3(randomX,7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if other is player 
        // destroy us
        // damage player.

        if(other.tag == "Player")
        {
            // take Player component from other game object.
            //check if that other game objeect has a Player component
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        // if other is laser
        // destroy laser
        // destroy us
        if(other.tag == "Laser")
        {
            if (player != null)
            {
                player.AddScore(10);

            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
