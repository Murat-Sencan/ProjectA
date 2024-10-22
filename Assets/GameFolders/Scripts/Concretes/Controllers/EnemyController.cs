using Abstracts.Animations;
using Abstracts.Combats;
using Abstracts.Controllers;
using Abstracts.Movements;
using Concretes.Animations;
using Concretes.EnemyStates;
using Concretes.Movements;
using Concretes.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        IMover _mover;
        IAnimation _animation;
        IFlip _flip;
        StateMachine _stateMachine;
        IEntityController _player;
        IHealth _health;

        [SerializeField] float moveSpeed = 2f;
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] bool isTakeHit = false;
        [SerializeField] Transform[] patrols;


        private void Awake()
        {
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new Flip(this);
            _stateMachine = new StateMachine();
            _health = GetComponent<IHealth>();
            _player = FindObjectOfType<PlayerController>();
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void Start()
        {
            Idle idle = new Idle(_mover, _animation);
            Walk walk = new Walk(this, _mover, _animation, _flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(this,_player, _mover, _flip, _animation, moveSpeed);
            Attack attack = new Attack();
            TakeHit takeHit = new TakeHit();
            Dead dead = new Dead();

            _stateMachine.AddTransition(idle, walk, () => idle.IsIdle == false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromEnemyToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromEnemyToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromEnemyToPlayer() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromEnemyToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromEnemyToPlayer() > attackDistance);

            _stateMachine.AddAnyState(dead, () => _health.CurrentHealth < 1);
            _stateMachine.AddAnyState(takeHit, () => isTakeHit);

            _stateMachine.AddTransition(takeHit, chasePlayer, () => isTakeHit == false);

            _stateMachine.SetState(idle);
        }

        void HandleHealthChanged()
        {
            isTakeHit = true;
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, chaseDistance);
        }

        float DistanceFromEnemyToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }
    }
}
