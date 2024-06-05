using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class ChasePlayer : IState
    {
        public void OnEnter()
        {
            Debug.Log("ChasePlayer On Enter");
        }

        public void OnExit()
        {
            Debug.Log("ChasePlayer On Exit");
        }

        public void Tick()
        {
            Debug.Log("ChasePlayer Tick");
        }
    }
}
