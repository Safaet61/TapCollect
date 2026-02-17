using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private int score = 0;
    [SerializeField] private int highestScore;

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
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
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
    public int GetCurrentScore( )
    {
        return score;
    }
    public int HighScore()
    {
        return highestScore;
    }
    public void CheckAndSaveHighScore()
    {
        if (score > highestScore)
        {
            highestScore = score;
        }
        PlayerPrefs.SetInt("HighestScore", highestScore);
    }
    public void HideScore()
    {
        scoreText.gameObject.SetActive(false);
    }
    
}
