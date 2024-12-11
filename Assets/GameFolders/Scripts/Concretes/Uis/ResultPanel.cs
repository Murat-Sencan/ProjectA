using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Concretes.Uis
{
    public class ResultPanel : MonoBehaviour
    {
        Text _resultMessage;

        private void Awake()
        {
            _resultMessage = transform.GetChild(0).GetComponent<Text>();
        }

        public void SetResultMessage(string result)
        {
            _resultMessage.text = result;
        }
    }
}
