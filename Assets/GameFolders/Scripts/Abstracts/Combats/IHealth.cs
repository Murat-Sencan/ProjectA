using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Combats
{
    public interface IHealth : ITakeHit
    {
        int CurrentHealth { get; }
        event System.Action OnHealthChanged;
    }
}
