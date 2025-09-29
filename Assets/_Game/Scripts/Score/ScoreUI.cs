using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreLevelText;
   [SerializeField] private TMP_Text scoreLevelTextUI;
   private ScoreController _scoreController;

   private void Awake()
   {
      _scoreController = FindObjectOfType<ScoreController>();
      _scoreController.onAddScore += ShowScore;
   }

   private void OnDestroy()
   {
      _scoreController.onAddScore -= ShowScore;
   }

   private void ShowScore()
   {
      scoreLevelText.text = _scoreController.LevelScore.ToString();
      scoreLevelTextUI.text = _scoreController.LevelScore.ToString();
   }

}
