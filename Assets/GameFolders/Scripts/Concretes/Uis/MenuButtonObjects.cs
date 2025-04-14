using Concretes.Enums;
using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Concretes.Uis
{
    public class MenuButtonObjects : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}