using Abstracts.Combats;
using Concretes.Combats;
using Concretes.Controllers;
using Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

namespace Concretes.Uis
{
    public class QuestionPanel : MonoBehaviour
    {
        [SerializeField] ResultPanel resultPanel;
        Text _messageText;
        int _lifeCount;
        IHealth _playerHealth;

        private void Awake()
        {
            _messageText = transform.GetChild(0).GetComponent<Text>();
        }

        private void OnDisable()
        {
            _lifeCount = 0;
            _playerHealth = null;
        }

        public void SetLifeCountAndReferences(int lifeCount, IHealth playerHealth)
        {
            _lifeCount = lifeCount;
            _messageText.text = $"{_lifeCount} can almak istiyor musun?";
            _playerHealth = playerHealth;
        }

        public void YesClick()
        {
            resultPanel.gameObject.SetActive(true);

            if(_lifeCount <= GameManager.Instance.Score)
            {
                resultPanel.SetResultMessage($"{_lifeCount} can aldýn");
                GameManager.Instance.DecreaseScore(_lifeCount);
                _playerHealth.Heal(_lifeCount);
            }
            else
            {
                resultPanel.SetResultMessage("yeterli elmasýn yok");
            }

            this.gameObject.SetActive(false);
        }
    }
}
