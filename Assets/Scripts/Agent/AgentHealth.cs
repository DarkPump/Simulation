using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private bool isDead = false;
    private bool isInvulnerable = false;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private Healthbar healthbar;

    //Ustawienie aktualnego zdrowia na maksymalne oraz aktualizacja paska zdrowia
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }
    //Otrzymywanie obra¿eñ, œmieræ
    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if(currentHealth > 0)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
            Debug.Log("Is alive");

            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!isDead)
            {
                Death();
            }
        }
    }
    //Funkcja odpowiedzialna za œmieræ obiektu
    private void Death()
    {
        isDead = true;
        gameObject.SetActive(false);
    }

    //Iframe
    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 7, true);
        yield return new WaitForSeconds(iFramesDuration);
        Physics2D.IgnoreLayerCollision(8, 7, false);
        isInvulnerable = false;
    }
}
