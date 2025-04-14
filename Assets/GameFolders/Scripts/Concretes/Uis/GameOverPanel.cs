using Concretes.Enums;
using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Concretes.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            SceneManager.LoadScene("Game");
        }

        public void NoButton()
        {
            GameManager.Instance.QuitGame();
        }
    }
}