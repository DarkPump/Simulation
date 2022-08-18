using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentSelection : MonoBehaviour
{
    [SerializeField] private GameObject currentSelectedAgent;
    [SerializeField] private float rayLength;
    [SerializeField] LayerMask layerMask;
    private Camera mainCamera;

    private void Awake()
    {
        InputManager.instance.EnablePlayerActionMap();
        mainCamera = Camera.main;
    }
    private void Start()
    {
        InputManager.instance.playerControls.Player.LeftClick.performed += ctx => SelectObject();
    }

    private void OnDestroy()
    {
        InputManager.instance.playerControls.Player.LeftClick.performed += ctx => SelectObject();
    }

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

    private void DeselectObject()
    {
        if(currentSelectedAgent != null)
        {
            currentSelectedAgent.transform.GetChild(0).gameObject.SetActive(false);
            currentSelectedAgent = null;
            Debug.Log("Deselecting");
        }
        else
        {
            currentSelectedAgent = null;
            Debug.Log("Deselecting");
        }
    }

    private void SelectObject(RaycastHit hit)
    {
        Debug.Log(hit.collider.name);
        currentSelectedAgent = hit.collider.gameObject;
        currentSelectedAgent.transform.GetChild(0).gameObject.SetActive(true);
    }
}
