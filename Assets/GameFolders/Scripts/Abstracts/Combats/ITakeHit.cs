using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Combats
{
    public interface ITakeHit
    {
        void TakeHit(IAttacker attacker);
    }
}
