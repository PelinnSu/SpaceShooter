using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserSpeed = 8f;


    void Update()
    {
        // translate laser up
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        //check if y>8, destroy laser
        if(transform.position.y > 8)
        {
            //destroy the object that THIS scriipt is attached to 

            if(transform.parent !=  null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
