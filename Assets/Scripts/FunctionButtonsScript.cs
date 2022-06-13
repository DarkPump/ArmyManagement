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
        if(buttonHighlight.currentButton == null || buttonHighlight.lastButton == null)
            swapButton.gameObject.GetComponent<Image>().color = Color.grey;
        else
            swapButton.gameObject.GetComponent<Image>().color = Color.black;
    }

    public void Swap()
    {
        UnitBase tmpUnit;
        Sprite tmpSprite;
        if((buttonHighlight.currentButtonUnit != null || buttonHighlight.lastButtonUnit != null))
        {
            tmpUnit = buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit;
            buttonHighlight.currentButton.gameObject.GetComponent<ButtonHandler>().unit = buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit;
            buttonHighlight.lastButton.gameObject.GetComponent<ButtonHandler>().unit = tmpUnit;

            tmpSprite = buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite;
            buttonHighlight.currentButton.gameObject.GetComponent<Image>().sprite = buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite;
            buttonHighlight.lastButton.gameObject.GetComponent<Image>().sprite = tmpSprite;
        }

    }

    public void Delete()
    {

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
