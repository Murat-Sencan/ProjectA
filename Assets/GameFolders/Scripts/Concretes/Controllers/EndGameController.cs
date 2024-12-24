using Concretes.Controllers;
using Concretes.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class EndGameController : MonoBehaviour
    {
        EndGameObject endGameObject;

        private void Start()
        {
            endGameObject = FindAnyObjectByType<EndGameObject>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                endGameObject.SetEndGamePanelActive(true);
            }
        }
    }
}
