using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button textButton;
    [SerializeField] TMP_InputField textBox;

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
}
