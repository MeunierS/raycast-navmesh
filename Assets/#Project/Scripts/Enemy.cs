using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [HideInInspector] public NavMeshAgent agent;
    public Transform waypoints;
    private EnemyStateMachine stateMachine;

    public bool CanSeePlayer(){
        Vector3 enemyFacing = transform.forward;
        Vector3 enemyPos = transform.position;
        Vector3 enemyToPlayer = target.position - enemyPos;
        Vector3 offset = Vector3.up * 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(enemyPos + offset, enemyToPlayer + offset, out hit, 10f)){
            if (hit.collider.CompareTag("Player")){
                if (Vector3.Angle(enemyFacing, enemyToPlayer)<= 45f){
                    return true;
                }
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(agent, target, this);
        stateMachine.Initialize(stateMachine.patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
