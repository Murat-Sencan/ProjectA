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
        IEntityController _enemy;
        IEntityController _player;
        IMover _mover;
        IFlip _flip;
        IAnimation _animation;
        float _moveSpeed;

        public ChasePlayer(IEntityController enemy, IEntityController player, IMover mover, IFlip flip, IAnimation animation, float moveSpeed)
        {
            _enemy = enemy;
            _player = player;
            _mover = mover;
            _flip = flip;
            _animation = animation;
            _moveSpeed = moveSpeed;
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
            Vector3 leftOrRight = _player.transform.position - _enemy.transform.position;
            if(leftOrRight.x > 0)
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
