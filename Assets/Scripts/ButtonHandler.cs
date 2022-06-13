using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    int tempCounter = 0;
    public bool isButtonClicked = false;
    [SerializeField] public GameObject canvas;
    [SerializeField] ButtonHighlight buttonHighlight;
    public UnitBase unit;
    public void HighlightButton()
    {
        if(canvas.gameObject.GetComponent<ButtonHighlight>().currentButton == null && isButtonClicked == false)
            isButtonClicked = true;
        else if(canvas.gameObject.GetComponent<ButtonHighlight>().lastButton == null && isButtonClicked == false)
            isButtonClicked = true;
            
        else
            isButtonClicked = false;
    }
}


//FIRST BUTTON PRESSED + SECOND BUTTON PRESSED + SPRAWDZANIE CZY MA PRZYPISANEGO BUTTONA DO TEJ ZMIENNEJ + JAK TAK TO ZAMIEŃ OSTATNI BUTTON NA NOWY BUTTON