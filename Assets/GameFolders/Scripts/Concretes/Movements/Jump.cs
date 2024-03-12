using Abstracts.Controllers;
using Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Movements
{
    public class Jump : IJump
    {
        Rigidbody2D _rigidBody;

        public Jump(Rigidbody2D rigidbody)
        {
            _rigidBody = rigidbody;
        }

        public void TickWithFixedUpdate(float jumpForce) 
        {
            _rigidBody.velocity = Vector2.zero;

            _rigidBody.AddForce(Vector2.up * jumpForce);

            _rigidBody.velocity = Vector2.zero;
        }
    }
}
