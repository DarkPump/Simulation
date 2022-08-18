using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : PoolableObject
{
    public AgentMovement movement;
    public NavMeshAgent agent;

    public override void OnDisable()
    {
        base.OnDisable();
        agent.enabled = false;
    }
}
