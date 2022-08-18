using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private bool isDead = false;

    [SerializeField] private Healthbar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }

    private void OnMouseDown()
    {
        ShowHealthbar();
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if(currentHealth > 0)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
            Debug.Log("Is alive");
        }
        else
        {
            if(!isDead)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private void ShowHealthbar()
    {
        healthbar.gameObject.SetActive(true);
    }
}
