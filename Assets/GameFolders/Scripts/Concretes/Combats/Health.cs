using Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth; 

        public bool IsDead => currentHealth < 1;

        public event System.Action OnHealthChanged;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            if(IsDead) return;

           currentHealth -= attacker.Damage;
            OnHealthChanged?.Invoke();
        }
    }
}
