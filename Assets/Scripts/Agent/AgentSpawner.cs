using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
    public int numberOfAgentsToSpawn = 30;
    [SerializeField] private int minSpawnDelay = 2;
    [SerializeField] private int maxSpawnDelay = 10;
    [SerializeField] private List<Agent> agentPrefabs = new List<Agent>();
    private int spawnDelay;

    private NavMeshTriangulation triangulation;
    private Dictionary<int, ObjectPool> agentObjectPools = new Dictionary<int, ObjectPool>();

    //Spawnowanie agentów z wykorzystaniem object poolingu

    private void Awake()
    {
        for(int i = 0; i < agentPrefabs.Count; i++)
        {
            agentObjectPools.Add(i, ObjectPool.CreateInstance(agentPrefabs[i], numberOfAgentsToSpawn));
        }
    }

    private void Start()
    {
        triangulation = NavMesh.CalculateTriangulation();

        StartCoroutine(SpawnAgents());
    }
    //Aktywowanie agentów co losow¹ liczbê sekund (kontrolowane z inspektora)
    private IEnumerator SpawnAgents()
    {
        int spawnedAgents = 0;
        while(spawnedAgents < numberOfAgentsToSpawn)
        {
            SpawnRandomAgent();
            spawnedAgents++;
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
    //Aktywowanie losowego prefabu jako agenta
    private void SpawnRandomAgent()
    {
        DoSpawnAgent(Random.Range(0, agentPrefabs.Count));
    }

    private void DoSpawnAgent(int spawnIndex)
    {
        PoolableObject poolableObject = agentObjectPools[spawnIndex].GetObject();

        if(poolableObject != null)
        {
            Agent agent = poolableObject.GetComponent<Agent>();

            int vertexIndex = Random.Range(0, triangulation.vertices.Length);
            NavMeshHit hit;

            if (NavMesh.SamplePosition(triangulation.vertices[vertexIndex], out hit, 2f, 1))
            {
                agent.agent.Warp(hit.position);
                agent.agent.enabled = true;
            }
        }
        else
        {
            Debug.LogError($"Unable to fetch agent of type {spawnIndex} from object pool");
        }
    }
}
