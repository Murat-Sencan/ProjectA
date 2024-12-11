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

        public event System.Action<SceneTypeEnum> OnSceneChanged;
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

        public void SplashScreen(string sceneName = "Menu")
        {
            SceneTypeEnum sceneType;

            switch (sceneName)
            {
                case "Game":
                    sceneType = SceneTypeEnum.Game; 
                    break;
                case "SplashScreen":
                    sceneType = SceneTypeEnum.Splash;
                    break;
                default:
                    sceneType = SceneTypeEnum.Menu;
                    break;
            }

            StartCoroutine(SplashScreenAsync(sceneName, sceneType));
        }

        private IEnumerator SplashScreenAsync(string sceneName, SceneTypeEnum sceneType)
        {
            yield return SceneManager.LoadSceneAsync("SplashScreen", LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneTypeEnum.Splash);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(1f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            OnSceneChanged.Invoke(sceneType);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
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
