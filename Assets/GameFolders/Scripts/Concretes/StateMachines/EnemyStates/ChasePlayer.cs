using Abstracts.Animations;
using Abstracts.Controllers;
using Abstracts.Movements;
using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class ChasePlayer : IState
    {
        IMover _mover;
        IFlip _flip;
        IAnimation _animation;
        System.Func<bool> _isPlayerRightSide;
        IStopEdge _stopEdge;
        float _moveSpeed;

        public ChasePlayer(IMover mover, IFlip flip, IAnimation animation, IStopEdge stopEdge, float moveSpeed, System.Func<bool> isPlayerRightSide)
        {
            _mover = mover;
            _flip = flip;
            _animation = animation;
            _moveSpeed = moveSpeed;
            _stopEdge = stopEdge;
            _isPlayerRightSide = isPlayerRightSide;
        }

        public void OnEnter()
        {
            _animation.MoveAnimation(1f);
        }

        public void OnExit()
        {
            _animation?.MoveAnimation(0f); 
        }

        public void Tick()
        {
            if(_stopEdge.ReachEdge())
            {
                _animation.MoveAnimation(0f);
                return;
            }

            if(_isPlayerRightSide.Invoke())
            {
                _mover.Tick(_moveSpeed * 1.2f);
                _flip.FlipCharacter(1f);
            }
            else
            {
                _mover.Tick(_moveSpeed * -1.2f);
                _flip.FlipCharacter(-1f);
            }

            Debug.Log("ChasePlayer Tick");
        }
    }
}
