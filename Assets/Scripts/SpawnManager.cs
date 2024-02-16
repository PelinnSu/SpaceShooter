using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyContainer;
    private bool stopSpawning = false;
    public GameObject[] powerUps;
    public Player player;
   
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine ());
        
    }

    void Update()
    {

    }
    /// while loop 
    /// instantiate enemy prefab
    /// yield wait for 5 seconds.
    IEnumerator SpawnEnemyRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(enemy, posToSpawn, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().player = this.player;
            // enemies will be instantiated under the spawn manager parent. 
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(2.0f);

        }
    }
    IEnumerator SpawnPowerUpRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(7, 14));
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
