using Abstracts.Combats;
using System;
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

        public event System.Action<int, int> OnHealthChanged;
        public event Action OnDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(IAttacker attacker)
        {
            if(IsDead) return;

            currentHealth = Math.Max(currentHealth -= attacker.Damage, 0);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
            AudioManager.Instance.Play("TakeHit");

            if (IsDead)
            {
                OnDead?.Invoke();
                AudioManager.Instance.Play("Death");
            }
        }

        public void Heal(int lifeCount)
        {
            currentHealth = Math.Min(currentHealth += lifeCount, maxHealth);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}
