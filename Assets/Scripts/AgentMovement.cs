using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.destination = goal.position;
    }
}
