using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    private void Update()
    {
        Vector3 v = mainCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(transform.position - mainCamera.transform.position);
        //transform.LookAt(mainCamera.transform.position - v);
        //transform.Rotate(0, 180, 0);
    }
}
