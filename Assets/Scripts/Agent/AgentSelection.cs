using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentSelection : MonoBehaviour
{
    [SerializeField] private float rayLength;
    [SerializeField] LayerMask layerMask;
    private Camera mainCamera;

    public GameObject currentSelectedAgent;
    public int currentAgentMaxHealth;
    public int currentAgentCurrentHealth;
    public bool isCurrentAgentDead;
    private AgentHealth agentHealth;

    private void Awake()
    {
        InputManager.instance.EnablePlayerActionMap();
        mainCamera = Camera.main;
        
    }
    private void Start()
    {
        InputManager.instance.playerControls.Player.LeftClick.performed += ctx => SelectObject();
    }

    private void Update()
    {
        DeselectDeadObject();
    }

    private void OnDestroy()
    {
        InputManager.instance.playerControls.Player.LeftClick.performed += ctx => SelectObject();
    }

    //Funkcja sprawdzaj�ca czy zaznaczony objekt jest agentem.
    private void SelectObject()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        bool agentHit = Physics.Raycast(ray, out hit, rayLength, layerMask);

        if (agentHit && currentSelectedAgent == null)
        {
            SelectObject(hit);

        }
        else if(agentHit && currentSelectedAgent != null)
        {
            DeselectObject();
            SelectObject(hit);
        }
        else if(!agentHit && currentSelectedAgent != null)
        {
            DeselectObject();
        }
        else if(!agentHit && currentSelectedAgent == null)
        {
            Debug.Log("empty");
        }
    }

    //Odznaczenie aktualnie wybranego agenta
    private void DeselectObject()
    {
        if(currentSelectedAgent != null)
        {
            currentSelectedAgent.transform.GetChild(0).gameObject.SetActive(false);
            currentSelectedAgent = null;
            UIManager.instance.UpdateNameValue(null);
            UIManager.instance.UpdateHealthValue(null, null);
            Debug.Log("Deselecting");
        }
        else
        {
            currentSelectedAgent = null;
            UIManager.instance.UpdateNameValue(null);
            UIManager.instance.UpdateHealthValue(null, null);
            Debug.Log("Deselecting");
        }
    }
    //Wy�wietlanie informacji o agencie (zycie oraz nazwa)
    private void SelectObject(RaycastHit hit)
    {
        Debug.Log(hit.collider.name);
        currentSelectedAgent = hit.collider.gameObject;
        currentSelectedAgent.transform.GetChild(0).gameObject.SetActive(true);

        agentHealth = currentSelectedAgent.GetComponent<AgentHealth>();
        isCurrentAgentDead = agentHealth.isDead;
        currentAgentMaxHealth = agentHealth.maxHealth;
        currentAgentCurrentHealth = agentHealth.currentHealth;

        UIManager.instance.UpdateNameValue(currentSelectedAgent.name);
        UIManager.instance.UpdateHealthValue(currentAgentMaxHealth, currentAgentCurrentHealth);
    }

    //Odznaczenie agenta po jego �mierci
    private void DeselectDeadObject()
    {
        if(currentSelectedAgent != null)
        {
            if(agentHealth.isDead)
            {
                DeselectObject();
            }
        }
    }
}
