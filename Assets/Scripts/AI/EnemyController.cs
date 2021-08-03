using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.AI
{
    public class EnemyController : MonoBehaviour
    {
        //i made this but didn't use it at all
        //enum EnemyState { Idle, Patrol, Combat };
        //collision
        Rigidbody2D rigidbody;
        //animation
        EnemyAnimationController enemyAnimationController;
        //action script references
        CombatAITree combatAITree;
        EnemyTakeDamage enemyTakeDamage;
        PatrolAITree patrolAITree;
        Wait wait;
        //detection cone


        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            combatAITree = GetComponent<CombatAITree>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            enemyTakeDamage = GetComponent<EnemyTakeDamage>();
            patrolAITree = GetComponent<PatrolAITree>();
            wait = GetComponent<Wait>();
            SwitchToIdle();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void SwitchToIdle()
        {
            //could make this a tree but so simple...
            wait.Run();
            SwitchToPatrol();//but this is a nono yeah? if idle changes i change this
        }
        void SwitchToPatrol()
        {
            patrolAITree.RunTree();
        }
        void SwitchToCombat()
        {
            combatAITree.RunTree();
        }
        //deals with cone detection
        void OnConeDetection()
        {
            patrolAITree.StopTree();
            SwitchToCombat();
        }
        void OnConeLoseDetection()
        {
            patrolAITree.StopTree();
            combatAITree.StopTree();
            SwitchToIdle();
        }
        //deals with proximity detection
        void OnProximityDetection()
        {
            patrolAITree.StopTree();
            SwitchToCombat();
        }
    }
}
