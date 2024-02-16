using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // handle to text.
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI RestartText;
    public Sprite[] livesSprites;
    public Image livesImg;
    private GameManager gameManager;
    void Start()
    {
        // assign text component to the handle.
        ScoreText.text = "Score: " + 0;
        GameOverText.gameObject.SetActive(false);
        RestartText.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        
        if ( gameManager == null )
        {
            Debug.Log("GameManager is Null");
        }
        

    }

    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        ScoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        livesImg.sprite = livesSprites[currentLives];
        if(currentLives == 0)
        {
            GameOverSequence();
            
        }
    }

    void GameOverSequence()
    {
        gameManager.GameOver();
        GameOverText.gameObject.SetActive(true);
        RestartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            GameOverText.text = "Game Over";
            yield return new WaitForSeconds(0.4f);
            GameOverText.text = "";
            yield return new WaitForSeconds(0.4f);

        }
    }
}
