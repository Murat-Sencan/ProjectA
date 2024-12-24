using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Uis
{
    public class EndGameObject : MonoBehaviour
    {
        [SerializeField] GameObject endGamePanel;

        public void SetEndGamePanelActive(bool state)
        {
            endGamePanel.SetActive(state);
        }

        private void OnDisable()
        {
            endGamePanel.SetActive(false);
        }
    }
}