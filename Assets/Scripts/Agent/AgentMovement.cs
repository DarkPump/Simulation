using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float walkRadius = 1f;

    private AgentAttack agentAttack;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agentAttack = GetComponent<AgentAttack>();
    }

    //Ruch do losowego punktu
    private void Update()
    {
        if (!agent.hasPath)
            agent.SetDestination(GetRandomPoint(transform, walkRadius));
    }
    //Czy losowy punkt jest dostêpny
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, 1))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    //Losowy punkt
    public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
    {
        Vector3 _point;

        if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? 1.0f : radius, out _point))
        {
            Debug.DrawRay(_point, Vector3.up, Color.black, 1);

            return _point;
        }

        return point == null ? Vector3.zero : point.position;
    }

    //Wyœwietlenie zasiêgu generowania losowego punktu
#if UNITY_EDITOR
    private void OnDrawGizmos()
        {
        Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, walkRadius);
        }

    #endif
}
