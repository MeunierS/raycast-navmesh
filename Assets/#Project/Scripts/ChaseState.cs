using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    private NavMeshAgent agent;
    private Transform target;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;

    public ChaseState(Enemy enemy, EnemyStateMachine stateMachine){
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        agent = enemy.agent;
        target = enemy.target;
    }
    public void Enter(){
        Debug.Log("Entering Chase State");
    }
    public void Perform(){
        agent.SetDestination(target.position);
        if (!enemy.CanSeePlayer()){
            stateMachine.TransistionTo(stateMachine.patrolState);
        }
    }
    public void Exit(){
        Debug.Log("Exiting Chase State");
    }
    
}
