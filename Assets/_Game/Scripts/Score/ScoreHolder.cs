using UnityEngine;


public class ScoreHolder : MonoBehaviour
{
    [SerializeField] private TypeScore type;
    private ScoreController _scoreController;
    
    private void Start()
    {
        _scoreController = FindObjectOfType<ScoreController>();
    }

    public void GetScore()
    {
        _scoreController.AddScore(type);
        if (type != TypeScore.Enemy)
        {
            Destroy(gameObject);
        }
    }
}
