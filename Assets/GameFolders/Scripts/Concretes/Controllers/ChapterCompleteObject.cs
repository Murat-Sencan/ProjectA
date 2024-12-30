using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class ChapterCompleteObject : MonoBehaviour
    {
        [SerializeField] GameObject ChapterCompletePanel;

        public void SetChapterPanelActive(bool state)
        {
            ChapterCompletePanel.SetActive(state);
        }

        private void OnDisable()
        {
            ChapterCompletePanel.SetActive(false);
        }
    }
}
