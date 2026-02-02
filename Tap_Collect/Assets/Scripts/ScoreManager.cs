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

    // Update is called once per frame
  public void updateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
