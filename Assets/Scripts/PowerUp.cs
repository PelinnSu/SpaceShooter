using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speed = 0.5f;
    // ID for powerups
    // 0 = Triple Shot
    // 1 = Speed
    // 2 = Shields
    public int powerUpID;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed *Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // communicate with the player script.
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
              switch (powerUpID)
                {
                    case 0:
                        Debug.Log("triple shot");
                        player.TripleShotActivee();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        Debug.Log("speed boost");
                        break;
                    case 2:
                        player.ShieldsActive();
                        Debug.Log("Shield collected");
                        break;
                    default:
                        Debug.Log("default value");
                        break;
                }
            }
            Destroy(this.gameObject) ;
        }
    }
}
