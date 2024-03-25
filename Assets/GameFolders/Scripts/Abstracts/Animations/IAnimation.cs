using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Animations
{
    public interface IAnimation
    {
        void MoveAnimation(float moveSpeed);
        void JumpAnimation(bool isJump);
        void AttackAnimation();
    }
}