using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Combats
{
    public interface IHealth : ITakeHit
    {
        bool IsDead { get; }
        event System.Action<int, int> OnHealthChanged;
        event System.Action OnDead;
    }
}
