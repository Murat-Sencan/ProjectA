using Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class DeathOnTouchController : MonoBehaviour
    {
        IAttacker _attacker;

        private void Awake()
        {
            _attacker = GetComponent<IAttacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth health = collision.GetComponent<IHealth>();

            if (health != null)
            {
                health.TakeHit(_attacker);
            }
        }
    }
}
