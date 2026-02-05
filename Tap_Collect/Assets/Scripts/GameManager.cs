using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button reStartButton;
    [SerializeField] public bool isGameOver;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            isGameOver = false;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

           
    }
    private void Start()
    {

        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        reStartButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void GameOver()
    {
        if (isGameOver)
            return;
        isGameOver = true;

        gameOverPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        reStartButton.gameObject.SetActive(true);

    }
    public  void Restart()
    {
        isGameOver = false;

        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        reStartButton.gameObject.SetActive(false);

        ScoreManager.instance.ResetScore();
        HealthManager.instance.ResetHealth();

    }
}

