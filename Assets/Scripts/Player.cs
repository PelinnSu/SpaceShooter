using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private float speedMultiplier = 2f;
    public GameObject laser;
    public GameObject tripleShotPrefab ;
    private float fireRate = 0.3f;
    private float canFire = -1f;
    public int lives = 3;
    private SpawnManager spawnManager;
    private bool isTripleShotActive = false;
    private bool isSpeedBoostActive = false;
    private bool isShieldActive = false;
    public GameObject shieldVisualizer;
    public int score;
    private UIManager uiManager;




    void Start()
    {
        // take current position
        transform.position = Vector3.zero;
        // get access to the spawn manager script.
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        if (spawnManager == null )
        {
            Debug.LogError("Spawn Manager is Null");
        }

        if(uiManager == null)
        {
            Debug.Log("The uý Manager is NULL");
        }
        
    }
    void Update()
    {

        CalculateMovement();
        FireLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        // if player position on the y is greater than 0
        // y position = 0;
        // else if poisition on the y is less than -3.8f
        // y pos = -3.8f
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        // if player on the x> 11
        // x pos = -11
        // else if player on the x is less than -11
        // x pos = 11
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);

        }


    }
    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            // cool down system. prevents non stop shooting.
            canFire = Time.time + fireRate;
            if(isTripleShotActive == true)
            {
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            
                // euler angle is rotation data.
                // Instantiate(laser , transform.position , Quaternion.identity); instantiates laser right were game object is.
                Instantiate(laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);

            

        }
    }

    public void Damage()
    {
        if(isShieldActive == true)
        {

            isShieldActive = false;
            shieldVisualizer.SetActive(false);
            return;

        }
        else
        {
            lives--;
            uiManager.UpdateLives(lives);

            //check if dead
            // destroy

            if (lives < 1)
            {
                // communicate with Spawn Manaager
                // let them knoow stop spawing.
                spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
       

       

    }

    public void TripleShotActivee()
    {
        //tripleShotActive becomes true
        // start the power down coroutine for triple shot.
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());

    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {
        isSpeedBoostActive = true;
        speed *= speedMultiplier;
        StartCoroutine (SpeedBoostPowerDownRoutine());  
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(3f);
        isSpeedBoostActive = false;
        speed /= speedMultiplier;

    }

    public void ShieldsActive()
    {
        isShieldActive = true;
        shieldVisualizer.SetActive(true);
    }

    public void AddScore(int point)
    {
        score += point;
        uiManager. UpdateScore(score);

    }


}
    

    

