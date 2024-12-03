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

        [SerializeField] float moveSpeed = 2f;

        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] float maxAttackTime = 2f;

        [SerializeField] Transform[] patrols;
        [SerializeField] ScoreController scorePrefab;

        [SerializeField] int currentChance;
        [SerializeField] int maxChance = 70;
        [SerializeField] int minChance = 20;

        StateMachine _stateMachine;
        IEntityController _player;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
        }

        private IEnumerator Start()
        {
            currentChance = Random.Range(minChance, maxChance);
            IMover mover = new Mover(this, moveSpeed);
            IAnimation animation = new PlayerAnimation(GetComponent<Animator>());
            IFlip flip = new Flip(this);
            IHealth health = GetComponent<IHealth>();
            IAttacker attacker = GetComponent<IAttacker>();
            IStopEdge stopEdge = GetComponent<IStopEdge>();

            Idle idle = new Idle(mover, animation);
            Walk walk = new Walk(this, mover, animation, flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(mover, flip, animation, stopEdge, moveSpeed, IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(), flip, animation, attacker, maxAttackTime, IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(health, animation);
            Dead dead = new Dead(this, animation, () =>
            {
                if (currentChance > Random.Range(0,100))
                {
                Instantiate(scorePrefab, transform.position, Quaternion.identity);
                }
            });

            _stateMachine.AddTransition(idle, walk, () => idle.IsIdle == false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromEnemyToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromEnemyToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromEnemyToPlayer() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromEnemyToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromEnemyToPlayer() > attackDistance);

            _stateMachine.AddAnyState(dead, () => health.IsDead);
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);

            _stateMachine.AddTransition(takeHit, chasePlayer, () => takeHit.IsTakeHit == false);

            _stateMachine.SetState(idle);

            yield return null;
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

        private bool IsPlayerRightSide()
        {
            Vector3 result = _player.transform.position - this.transform.position;

            if(result.x > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
