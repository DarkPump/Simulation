using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    [SerializeField] private TMP_Text text;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        text.text = transform.parent.name.ToLower();
    }
    //Aktualizacja paska zdrowia
    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }


    //Ukierunkowanie element�w ui w stron� kamery
    private void Update()
    {
        Vector3 v = mainCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(transform.position - mainCamera.transform.position);
    }
}
