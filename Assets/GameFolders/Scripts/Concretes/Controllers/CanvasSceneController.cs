using Concretes.Enums;
using Concretes.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class CanvasSceneController : MonoBehaviour
    {
        [SerializeField] SceneTypeEnum sceneType;
        [SerializeField] GameObject canvasObject;

        private void Start()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(SceneTypeEnum sceneType)
        {
            if(sceneType == this.sceneType)
            {
                canvasObject.SetActive(true);
            }
            else
            {
                canvasObject.SetActive(false);
            }
        }
    }
}
