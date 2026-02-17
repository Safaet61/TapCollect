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
        GamePlayPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        GamePlayPanel.SetActive(false);
    }

}
