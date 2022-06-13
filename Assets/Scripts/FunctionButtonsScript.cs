using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FunctionButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] ButtonHighlight buttonHighlight;
    [SerializeField] Button swapButton;
    [SerializeField] Button deleteButton;
    [SerializeField] Sprite baseSprite;
    public UnitBase unitx1;
    public UnitBase unitx2;

    private void Awake()
    {
        buttonHighlight = canvas.gameObject.GetComponent<ButtonHighlight>();
    }
    private void Update() 
    {
        CheckIfUnitsHighlighted();
    }
    
    public void CheckIfUnitsHighlighted()
    {
        if((buttonHighlight.currentButtonUnit != null || buttonHighlight.lastButtonUnit != null) && (buttonHighlight.currentButton != null && buttonHighlight.lastButton != null))
        {
            swapButton.gameObject.GetComponent<Button>().enabled = true;
            swapButton.gameObject.GetComponent<Image>().color = Color.black;
        }
        else
        {
            swapButton.gameObject.GetComponent<Image>().color = Color.grey;
            swapButton.gameObject.GetComponent<Button>().enabled = false;
        }

        if(buttonHighlight.currentButtonUnit != null || buttonHighlight.lastButtonUnit != null)
        {
            deleteButton.gameObject.GetComponent<Button>().enabled = true;
            deleteButton.gameObject.GetComponent<Image>().color = Color.black;
            
        }
        else
        {
            deleteButton.gameObject.GetComponent<Image>().color = Color.grey;
            deleteButton.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void Swap()
    {
        UnitBase tmpUnit;
        Sprite tmpSprite;
        if(buttonHighlight.currentButtonUnit != null || buttonHighlight.lastButtonUnit != null)
        {
            tmpUnit = buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit;
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit;
            buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit = tmpUnit;

            tmpUnit = buttonHighlight.currentButtonUnit;
            buttonHighlight.currentButtonUnit = buttonHighlight.lastButtonUnit;
            buttonHighlight.lastButtonUnit = tmpUnit;

            tmpSprite = buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite;
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite;
            buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = tmpSprite;
        }

    }

    public void Delete()
    {
        if(buttonHighlight.currentButton != null && buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = null;
            buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit = null;

            buttonHighlight.currentButtonUnit = null;
            buttonHighlight.lastButtonUnit = null;
    
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = baseSprite;
            buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = baseSprite;
        }
        else if(buttonHighlight.currentButton != null || buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = null;
            buttonHighlight.currentButtonUnit = null;
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = baseSprite;
        }



    }

    public void Addx1()
    {
        if(buttonHighlight.currentButton != null && buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = unitx1;
            buttonHighlight.currentButtonUnit = unitx1;
            
            buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit = unitx1;
            buttonHighlight.lastButtonUnit = unitx1;

            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = unitx1.unitSprite;
            buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = unitx1.unitSprite;
        }
        else if(buttonHighlight.currentButton != null || buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = unitx1;
            buttonHighlight.currentButtonUnit = unitx1;
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = unitx1.unitSprite;
        }
    }

    public void Addx2()
    {
        if(buttonHighlight.currentButton != null && buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = unitx2;
            buttonHighlight.currentButtonUnit = unitx2;

            buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit = unitx2;
            buttonHighlight.lastButtonUnit = unitx2;

            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = unitx2.unitSprite;
            buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = unitx2.unitSprite;
        }
        else if(buttonHighlight.currentButton != null || buttonHighlight.lastButton != null)
        {
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = unitx2;
            buttonHighlight.currentButtonUnit = unitx2;
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = unitx2.unitSprite;
        }
    }

    public void UpdateUnitInfo()
    {
        buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = buttonHighlight.currentButtonUnit.unitSprite;
        buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = buttonHighlight.lastButtonUnit.unitSprite;
    }
}
