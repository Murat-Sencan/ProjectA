using Abstracts.Animations;
using Abstracts.Combats;
using Abstracts.Controllers;
using Abstracts.Inputs;
using Abstracts.Movements;
using Concretes.Animations;
using Concretes.Inputs;
using Concretes.Movements;
using Concretes.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        IPlayerInput _input;
        IMover _mover;
        IAnimation _animation;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        IHealth _health;

        float _horizontal;
        [SerializeField] float _moveSpeed;

        [SerializeField] float _jumpForce;
        bool _isJump = false;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new Mover(this, _moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new Flip(this);
            _jump = new Jump(GetComponent<Rigidbody2D>());
            _onGround = GetComponent<IOnGround>();
            _health = GetComponent<IHealth>();
        }

        private void OnEnable()
        {
            _health.OnDead += _animation.DeadAnimation;
        }

        private void Start()
        {
            GameOverObject gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);
        }

        private void Update()
        {
            if(_health.IsDead) return;

            _horizontal = _input.Horizontal;

            if(_input.AttackButtonDown && _horizontal == 0f)
            {
                _animation.AttackAnimation();
                return;
            }

            if (_input.JumpButtonDown && _onGround.IsGround)
            {
                _isJump = true;
            }

            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }

        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal * _moveSpeed);
            
            if( _isJump && _onGround.IsGround)
            {
                _jump.TickWithFixedUpdate(_jumpForce);
                _isJump=false;
            }
        }
    }
}
