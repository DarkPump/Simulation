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
