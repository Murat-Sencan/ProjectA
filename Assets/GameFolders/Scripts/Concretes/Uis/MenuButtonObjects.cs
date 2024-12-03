using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Uis
{
    public class MenuButtonObjects : MonoBehaviour
    {
        public void StartGame(string levelName)
        {
            GameManager.Instance.SplashScreen(levelName);
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}