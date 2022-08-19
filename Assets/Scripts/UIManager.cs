using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button textButton;
    [SerializeField] TMP_InputField textBox;

    [SerializeField] TMP_Text healthValue;
    [SerializeField] TMP_Text nameValue;

    [SerializeField] AgentSelection agentSelection;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Uzupe³nienie pola tekstowego liczbami oraz marko polo
    public void PopulateTextBox()
    {
        for(int i = 1; i < 101; i++)
        {
            if(i % 3 == 0 && i % 5 == 0)
                textBox.text += "MarkoPolo ";
            else if(i % 3 == 0)
                textBox.text += "Marko ";
            else if(i % 5 == 0)
                textBox.text += "Polo ";
            else
                textBox.text += i.ToString() + " ";
        }
        textButton.interactable = false;
    }

    //Aktualizacja nazwy agenta w overlayu
    public void UpdateNameValue(string agentName)
    {
        nameValue.text = agentName;
    }

    //Aktualizacja zycia agenta w overlayu
    public void UpdateHealthValue(int? maxHealth, int? currentHealth)
    {
        if (maxHealth.HasValue)
            healthValue.text = currentHealth + "/" + maxHealth;
        else
            healthValue.text = null;
    }
}
