using Abstracts.Controllers;
using Abstracts.Movements;
using Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Movements
{
    public class Mover : IMover
    {
        IEntityController _entityController;
        float _moveSpeed;

        public Mover(IEntityController entityController, float moveSpeed)
        {
            _entityController = entityController;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            _entityController.transform.Translate(Vector2.right * horizontal * Time.deltaTime);
        }
    }
}
