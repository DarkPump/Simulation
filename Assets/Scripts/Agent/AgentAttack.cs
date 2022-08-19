using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private float knockbackDuration;
    [SerializeField] private float knockbackForce;
    [SerializeField] LayerMask agentLayer;
    public float knockbackCounter;

    //Zadawanie obra¿eñ przy kontakcie z innym agentem
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Agent"))
        {
            Debug.Log("damage!");
            other.gameObject.GetComponent<AgentHealth>().TakeDamage(damage);
        }
    }
}
