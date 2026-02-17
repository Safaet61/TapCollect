using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int score = 0;

    [SerializeField] public  TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        scoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void updateScore(int value)
    {
        score += value;
        ScoreUI();
    }
    void ScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
    public void ResetScore()
    {
        scoreText.gameObject.SetActive(true) ;
        score = 0;
        ScoreUI();
    }
    public void TotalScore( )
    {
        int totalScore;
    }
    public void HighScore(int scoreH)
    {
        PlayerPrefs.GetInt("HighScore", 0);
        if (scoreH > score)
        {
            PlayerPrefs.SetInt("HighScore", scoreH);
        }
    }
    public void HideScore()
    {
        scoreText.gameObject.SetActive(false);
    }
}
