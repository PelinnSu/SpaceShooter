using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.R) && isGameOver == true)
       {
            SceneManager.LoadScene("SampleScene");
       }
    }
    public void GameOver()
    {
        isGameOver = true;
    }
}
