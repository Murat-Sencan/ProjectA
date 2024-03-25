using Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => throw new System.NotImplementedException();

        public float Vertical => throw new System.NotImplementedException();

        public bool JumpButtonDown => throw new System.NotImplementedException();

        public bool AttackButtonDown => throw new System.NotImplementedException();
    }
}
