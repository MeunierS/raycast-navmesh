using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState
{
    private NavMeshAgent agent;
    private Transform waypoints;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;
    public bool isAtDestination { get {return agent.remainingDistance <= agent.stoppingDistance;} }
    public PatrolState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy= enemy; 
        this.stateMachine= stateMachine;
        agent = enemy.agent;
        waypoints = enemy.waypoints;
    }
    private void SelectDestination(){
        int numWaypoints = waypoints.childCount;
        int rndIndex = Random.Range(0, numWaypoints);
        Transform target = waypoints.GetChild(rndIndex);
        agent.SetDestination(target.position);
    }
    public void Enter(){
        Debug.Log("Entering Patrol State");
        SelectDestination();
    }
    public void Perform(){
        if (isAtDestination)
        {
            SelectDestination();
        }
        if (enemy.CanSeePlayer()){
            stateMachine.TransistionTo(stateMachine.chaseState);
        }
    }
    public void Exit(){
        Debug.Log("Exiting Patrol State");
    }
}
