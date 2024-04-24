using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoToTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] protected Transform[] targets;
    private int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // if(target !=null){
        //     agent.SetDestination(target.position);
        // }
        if(index < targets.Length){
            if(agent.remainingDistance <= agent.stoppingDistance){
                index++;
                if(index < targets.Length){
                SetDestination();
                }
            }
        }
        else{
            index=0;
            SetDestination();
        }
    }
    void SetDestination(){
        agent.SetDestination(targets[index].position);
    }
}
