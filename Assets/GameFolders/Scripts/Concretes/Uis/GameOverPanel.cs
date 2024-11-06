using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.SplashScreen("Game");
        }

        public void NoButton()
        {
            GameManager.Instance.SplashScreen();
        }
    }
}