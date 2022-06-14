using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    int buttonIndex;
    public bool isButtonClicked = false;
    [SerializeField] public GameObject canvas;
    [SerializeField] ButtonHighlight buttonHighlight;
    public Button currentButton;
    public UnitBase unit;
    public GameObject highlighter;
    public Image currentImage;
    public Sprite baseSprite;


    public void HighlightButton()
    {
        if(canvas.gameObject.GetComponent<ButtonHighlight>().currentButton == null && isButtonClicked == false)
            isButtonClicked = true;
        else if(canvas.gameObject.GetComponent<ButtonHighlight>().lastButton == null && isButtonClicked == false)
            isButtonClicked = true;
        else
            isButtonClicked = false;
    }

    public void AssignButtonIndex(int indexValue)
    {
        buttonIndex = indexValue;
    }

    public int GetCurrentButtonIndexValue()
    {
        return buttonIndex;
    }

    public void Delete()
    {
        unit = null;
        unit = null;

        currentImage.sprite = baseSprite;
        currentImage.sprite = baseSprite;
    }
}


//FIRST BUTTON PRESSED + SECOND BUTTON PRESSED + SPRAWDZANIE CZY MA PRZYPISANEGO BUTTONA DO TEJ ZMIENNEJ + JAK TAK TO ZAMIEŃ OSTATNI BUTTON NA NOWY BUTTON