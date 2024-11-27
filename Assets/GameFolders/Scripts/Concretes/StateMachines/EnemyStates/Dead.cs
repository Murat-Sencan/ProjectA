using Abstracts.Animations;
using Abstracts.Controllers;
using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Dead : IState
    {
        IAnimation _animation;
        IEntityController _controller;
        System.Action _deadCallback;

        float _currentTime = 0f;

        public Dead(IEntityController controller, IAnimation animation, System.Action deadCallback)
        {
            _animation = animation;
            _controller = controller;
            _deadCallback = deadCallback;
        }

        public void OnEnter()
        {
            _animation.DeadAnimation();
            _deadCallback?.Invoke();
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;
            if(_currentTime > 5f) Object.Destroy(_controller.transform.gameObject);

            Debug.Log("Dead Tick");
        }
    }
}
