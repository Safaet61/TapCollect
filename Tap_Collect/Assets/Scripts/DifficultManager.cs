using UnityEngine;

public class DifficultManager : MonoBehaviour
{
    public static DifficultManager instance;

    [SerializeField] private ObstacleSpawn obstacleSpawn;

    [SerializeField] private LevelDifficulty easy;
    [SerializeField] private LevelDifficulty medium;
    [SerializeField] private LevelDifficulty hard;

    public LevelDifficulty currentDifficulty;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetEasy()
    {
        currentDifficulty = easy;
        obstacleSpawn.RunGame();
        GameManager.instance.ShowScoreHealth();
        
    }

    public void SetMedium()
    {
        currentDifficulty = medium;
        obstacleSpawn.RunGame();
        GameManager.instance.ShowScoreHealth();
    }

    public void SetHard()
    {
        currentDifficulty = hard;
        obstacleSpawn.RunGame(); 
        GameManager.instance.ShowScoreHealth();
    }
}
