using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class Attack : IState
    {
        public void OnEnter()
        {
            Debug.Log("Attack On Enter");
        }

        public void OnExit()
        {
            Debug.Log("Attack On Exit");
        }

        public void Tick()
        {
            Debug.Log("Attack Tick");
        }
    }
}  

