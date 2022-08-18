using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField] private GameObject agentPrefab;
    private int minSpawnTime = 2;
    private int maxSpawnTime = 10;
    private int spawnTime;
    private IEnumerator InstantiateAgent()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(spawnTime);
        //Instantiate(agentPrefab, )
    }
}
