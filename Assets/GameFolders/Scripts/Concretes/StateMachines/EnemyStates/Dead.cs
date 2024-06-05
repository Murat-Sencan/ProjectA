using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Dead : IState
    {
        public void OnEnter()
        {
            Debug.Log("Dead On Enter");
        }

        public void OnExit()
        {
            Debug.Log("Dead On Exit");
        }

        public void Tick()
        {
            Debug.Log("Dead Tick");
        }
    }
}
