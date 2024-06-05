using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Walk : IState
    {
        public void OnEnter()
        {
            Debug.Log("Walk On Enter");
        }

        public void OnExit()
        {
            Debug.Log("Walk On Exit");
        }

        public void Tick()
        {
            Debug.Log("Walk Tick");
        }
    }
}
