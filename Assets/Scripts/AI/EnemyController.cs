using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.AI
{
    public class EnemyController : MonoBehaviour
    {
        //i made this but didn't use it at all
        public enum EnemyState { Idle, Patrol, Combat };
        //collision
        Rigidbody2D rigidbody;
        //animation
        EnemyAnimationController enemyAnimationController;
        //action script references
        CombatAITree combatAITree;
        IdleAITree idleAITree;
        EnemyTakeDamage enemyTakeDamage;
        PatrolAITree patrolAITree;
        Wait wait;
        [SerializeField] FieldOfViewCone fieldOfViewCone;
        [SerializeField] FieldOfViewCone playerDetectionCone;
        //detection cone


        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            combatAITree = GetComponent<CombatAITree>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            enemyTakeDamage = GetComponent<EnemyTakeDamage>();
            idleAITree = GetComponent<IdleAITree>();
            patrolAITree = GetComponent<PatrolAITree>();
            wait = GetComponent<Wait>();
            SwitchToIdle();
        }

        // Update is called once per frame
        void Update()
        {
            fieldOfViewCone.SetOrigin(transform.position);
            fieldOfViewCone.SetAimDirection(Vector2.left);//set direction based on movement
            playerDetectionCone.SetOrigin(transform.position);
            playerDetectionCone.SetAimDirection(Vector2.left);
        }

        void SwitchToIdle()
        {
            idleAITree.Run();
        }
        void SwitchToPatrol()
        {
            patrolAITree.Run();
        }
        void SwitchToCombat()
        {
            combatAITree.Run();
        }
        //deals with cone detection
        void OnConeDetection()
        {
            patrolAITree.Halt();
            SwitchToCombat();
        }
        void OnConeLoseDetection()
        {
            patrolAITree.Halt();
            combatAITree.Halt();
            SwitchToIdle();
        }
        //deals with proximity detection
        void OnProximityDetection()
        {
            patrolAITree.Halt();
            SwitchToCombat();
        }

        public void ChangeStates(EnemyState enemyState)
        {
            switch (enemyState)
            {
                case EnemyState.Combat:
                    SwitchToCombat();
                    break;
                case EnemyState.Idle:
                    SwitchToIdle();
                    break;
                case EnemyState.Patrol:
                    SwitchToPatrol();
                    break;
                default:
                    SwitchToIdle();
                    break;
            }
        }
    }
}
