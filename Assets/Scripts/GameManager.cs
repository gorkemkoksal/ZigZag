using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    int score;
    [SerializeField] Text scoreDisplay;
    [SerializeField] Text highScoreText;
    

    private void Awake()
    {
        highScoreText.text = "Best: " + GetHighScore().ToString();
        
    }
    public void StartGame()
    {
        isStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartGame();
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
    public void GettingScore()
    {
        score++;
        scoreDisplay.text = score.ToString();
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text ="Best: " + score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore",0);
        return i;
    }
}
