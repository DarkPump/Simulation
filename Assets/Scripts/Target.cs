using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer agentRenderer;
    public Color originalColor;
    
    //Zmiana koloru agenta po najechaniu na niego kursorem

    private void Awake()
    {
        agentRenderer = GetComponent<Renderer>();
        originalColor = agentRenderer.material.color;
    }
    private void OnMouseEnter()
    {
        agentRenderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        agentRenderer.material.color = originalColor;
    }
}
