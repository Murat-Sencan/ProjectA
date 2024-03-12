using Abstracts.Movements;
using Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Movements
{
    public class Mover : IMover
    {
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Tick(float horizontal)
        {
            _playerController.transform.Translate(Vector2.right * horizontal * Time.deltaTime);
        }
    }
}
