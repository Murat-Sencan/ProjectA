using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Idle : IState
    {
        public void OnEnter()
        {
            Debug.Log("Idle On Enter");
        }

        public void OnExit()
        {
            Debug.Log("Idle On Exit");
        }

        public void Tick()
        {
            Debug.Log("Idle Tick");
        }
    }
}
