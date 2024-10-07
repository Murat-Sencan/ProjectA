using Abstracts.Animations;
using Abstracts.Movements;
using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Walk : IState
    {
        IMover _mover;
        IAnimation _animation;
        IFlip _flip;

        float _direction = 1f;
        Transform[] _patrols;

        public bool IsWalking { get; private set; }

        public Walk(IMover mover, IAnimation animation, IFlip flip, params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _flip = flip;
            _patrols = patrols;
        }

        public void OnEnter()
        {
            _animation.MoveAnimation(1f);
            IsWalking = true;

            Debug.Log("Walk On Enter");
        }

        public void OnExit()
        {
            _direction *= -1;
            _flip.FlipCharacter(_direction);
            IsWalking = false;
            _animation.MoveAnimation(0f);
            Debug.Log("Walk On Exit");
        }

        public void Tick()
        {
            _mover.Tick(_direction);
            Debug.Log("Walk Tick");
        }
    }
}
