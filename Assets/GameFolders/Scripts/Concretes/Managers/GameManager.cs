using Concretes.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int score; 

        public static GameManager Instance { get; private set; }

        public int Score => score;

        public event System.Action<int> OnScoreChanged;

        private void Awake()
        {
            SingletonThisObject();
        }

        void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void IncreaseScore(int scorePoint)
        {
            score += scorePoint;
            OnScoreChanged?.Invoke(score);
        }

        public void DecreaseScore(int scorePoint)
        {
            score -= scorePoint;
            OnScoreChanged?.Invoke(score);
        }
    }
}
