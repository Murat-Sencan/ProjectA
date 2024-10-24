using Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] int maxHealth = 3;

        int _currentHealth;
        public int CurrentHealth => _currentHealth;

        public event System.Action OnHealthChanged;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
           _currentHealth -= attacker.Damage;
            OnHealthChanged?.Invoke();
        }
    }
}
