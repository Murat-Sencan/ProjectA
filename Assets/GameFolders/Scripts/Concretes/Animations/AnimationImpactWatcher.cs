using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Animations
{
    public class AnimationImpactWatcher : MonoBehaviour
    {
        public event System.Action OnImpact;

        public void Impact()
        {
            OnImpact?.Invoke();
        }
    }
}
