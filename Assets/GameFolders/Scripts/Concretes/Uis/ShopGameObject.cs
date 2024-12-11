using Abstracts.Combats;
using Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Uis
{
    public class ShopGameObject : MonoBehaviour
    {
        [SerializeField] QuestionPanel questionPanel;

        IHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void OnDisable()
        {
            _playerHealth = null;
        }

        public void BuyLifeClick(int lifeCount)
        {
            questionPanel.gameObject.SetActive(true);
            questionPanel.SetLifeCountAndReferences(lifeCount, _playerHealth);
        }
    }
}
