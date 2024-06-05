using Abstracts.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.EnemyStates
{
    public class TakeHit : IState
    {
        public void OnEnter()
        {
            Debug.Log("TakeHit On Enter");
        }

        public void OnExit()
        {
            Debug.Log("TakeHit On Exit");
        }

        public void Tick()
        {
            Debug.Log("TakeHit Tick");
        }
    }
}
