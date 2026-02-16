using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] public GameObject GamePlayPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    public void ShowGamePlayPanel()
    {

    }
    public void OffGamePlayPanel()
    {

    }
    public void ShowGameOverPanel()
    {

    }
    public void OffGameOverPanel()
    {

    }
    public void ShowScore()
    {

    }
    public void OffScore()
    {

    }
    public void ShowHealth()
    {

    }
    public void OffHealth()
    {

    }
}
