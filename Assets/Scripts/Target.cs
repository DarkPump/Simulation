using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer agentRenderer;
    public Color originalColor;
    // Start is called before the first frame update

    private void Awake()
    {
        agentRenderer = GetComponent<Renderer>();
        originalColor = agentRenderer.material.color;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
