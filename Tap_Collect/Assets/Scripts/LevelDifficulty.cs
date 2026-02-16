using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Game/Difficulty")]
public class LevelDifficulty : ScriptableObject
{
    public string difficultyName;
    public float spawnDelay;
}