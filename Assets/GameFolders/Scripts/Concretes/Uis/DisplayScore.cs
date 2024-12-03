using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Concretes.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<Text>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
