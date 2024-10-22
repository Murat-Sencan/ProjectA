using Abstracts.Animations;
using Abstracts.Controllers;
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
        IEntityController _entityController;

        int _patrolIndex = 0;
        float _direction;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController, IMover mover, IAnimation animation, IFlip flip, params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _flip = flip;
            _patrols = patrols;
            _entityController = entityController;
        }

        public void OnEnter()
        {
            _currentPatrol = _patrols[_patrolIndex];

            Vector3 leftOrRight = _currentPatrol.position - _entityController.transform.position;
            _flip.FlipCharacter(leftOrRight.x > 0f ? 1f : -1f);

            _direction = _entityController.transform.localScale.x;

            _animation.MoveAnimation(1f);
            IsWalking = true;
        }

        public void OnExit()
        {
            _animation.MoveAnimation(0f);
            _patrolIndex++;
            if (_patrolIndex >= _patrols.Length)
            {
                _patrolIndex = 0;
            }
        }

        public void Tick()
        {
            if(Vector2.Distance(_entityController.transform.position, _currentPatrol.position) <= 0.2f)
            {
                IsWalking = false;
                return;
            }

            _mover.Tick(_direction);
            Debug.Log("Walk Tick");
        }
    }
}
