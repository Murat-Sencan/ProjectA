using Abstracts.Animations;
using Abstracts.Combats;
using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class TakeHit : IState
    {
        IAnimation _animation;

        float _maxDelayTime = 0.1f;
        float _currentDelayTime = 0f; 

        public bool IsTakeHit { get; set; }

        public TakeHit(IHealth health, IAnimation animation)
        {
            _animation = animation;
            health.OnHealthChanged += OnEnter;
        }

        public void OnEnter()
        {
            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;

            if(_currentDelayTime > _maxDelayTime && IsTakeHit)
            {
                _animation.TakeHitAnimation();
                IsTakeHit = false;
            }

            Debug.Log("TakeHit Tick");
        }
    }
}
