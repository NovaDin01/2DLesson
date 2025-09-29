using System;
using UnityEngine;

public enum TypeScore
{
    Diamond,
    Enemy
}

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int scoreDiamond = 10;
    [SerializeField] private int scoreEnemy = 50;

    private int levelScore;
    private int allScore;

    public event Action onAddScore;

    public void AddScore(TypeScore type)
    {
        switch (type)
        {
            case TypeScore.Diamond:
                levelScore += scoreDiamond;
                allScore += scoreDiamond;
                break;
            case TypeScore.Enemy:
                levelScore += scoreEnemy;
                allScore += scoreEnemy;
                break;
        }
        onAddScore?.Invoke();
    }

    public int LevelScore => levelScore;
    public int AllScore => allScore;
    
}