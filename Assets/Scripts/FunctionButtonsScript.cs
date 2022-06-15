using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class FunctionButtonsScript : MonoBehaviour
{
    [SerializeField] List<Button> topUnits;
    [SerializeField] List<Button> botUnits;
    [SerializeField] GameObject canvas;
    [SerializeField] ButtonHighlight buttonHighlight;
    [SerializeField] Button swapButton;
    [SerializeField] Button deleteButton;
    [SerializeField] Button add1Button;
    [SerializeField] Button add2Button;
    [SerializeField] Sprite baseSprite;
    public UnitBase unitx1;
    public UnitBase unitx2;
    public 
    int unitIndex;

    private void Awake()
    {
        buttonHighlight = canvas.gameObject.GetComponent<ButtonHighlight>();
        int unitsCount = topUnits.Count;
    }
    private void Update() 
    {
        CheckIfUnitsHighlighted();
    }
    
    public void CheckIfUnitsHighlighted()
    {
        //Swap button
        if((buttonHighlight.currentButtonUnit != null || buttonHighlight.lastButtonUnit != null) && (buttonHighlight.currentButton != null && buttonHighlight.lastButton != null))
        {
            swapButton.enabled = true;
            swapButton.gameObject.GetComponent<Image>().color = Color.black;
        }
        else
        {
            swapButton.gameObject.GetComponent<Image>().color = Color.grey;
            swapButton.gameObject.GetComponent<Button>().enabled = false;
        }
        
        //Delete button
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

        //Add x1 button
        if(buttonHighlight.currentButtonUnit != null && buttonHighlight.lastButtonUnit != null)
        {
            add1Button.gameObject.GetComponent<Image>().color = Color.grey;
            add1Button.gameObject.GetComponent<Button>().enabled = false;
        }
        if(buttonHighlight.currentButtonUnit != null && buttonHighlight.lastButtonUnit == null)
        {
            add1Button.gameObject.GetComponent<Image>().color = Color.grey;
            add1Button.gameObject.GetComponent<Button>().enabled = false;
        }
        else if(buttonHighlight.currentButton != null)
        {
            add1Button.gameObject.GetComponent<Button>().enabled = true;
            add1Button.gameObject.GetComponent<Image>().color = Color.black;
        }
        else
        {
            add1Button.gameObject.GetComponent<Image>().color = Color.grey;
            add1Button.gameObject.GetComponent<Button>().enabled = false;
        }

        //Add x2 button
        if((buttonHighlight.currentButton != null && buttonHighlight.lastButton == null) && (buttonHighlight.currentButton.transform == topUnits.Last().transform 
                                                                                          || buttonHighlight.currentButton.transform == botUnits.Last().transform))
        {
            add2Button.gameObject.GetComponent<Image>().color = Color.grey;
            add2Button.gameObject.GetComponent<Button>().enabled = false;
        }
        else if((buttonHighlight.currentButton != null && buttonHighlight.lastButton != null) && (buttonHighlight.currentButton.transform == topUnits.Last().transform 
                                                                                          || buttonHighlight.currentButton.transform == botUnits.Last().transform 
                                                                                          || buttonHighlight.lastButton.transform == topUnits.Last().transform
                                                                                          || buttonHighlight.lastButton.transform == botUnits.Last().transform))
        {
            add2Button.gameObject.GetComponent<Image>().color = Color.grey;
            add2Button.gameObject.GetComponent<Button>().enabled = false;
        }
        else if(buttonHighlight.currentButton != null)
        {
            add2Button.gameObject.GetComponent<Button>().enabled = true;
            add2Button.gameObject.GetComponent<Image>().color = Color.black;
        }
        else
        {
            add2Button.gameObject.GetComponent<Image>().color = Color.grey;
            add2Button.gameObject.GetComponent<Button>().enabled = false;
        }

    }
    //Granica 1, a przed nim 2. Z treści zadania
    //identyfikatory kazdego slota
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
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
        TryDeleteNextUnitSlot(cachedCurrentButtonHandler);
        TryDeleteNextUnitSlot(cachedLastButtonHandler);
        cachedCurrentButtonHandler?.Delete();
        cachedLastButtonHandler?.Delete();
    }

    public void TryDeleteNextUnitSlot(ButtonHandler buttonHandler)
    {
        ButtonHandler cachedNextButtonHandler;

        if(buttonHandler?.unit?.unitSize > 1)
        {
            for(int i = 1 ; i < buttonHandler.unit.unitSize; i++)
            {
                cachedNextButtonHandler = buttonHighlight.buttonHandlersCollection[buttonHandler.GetCurrentButtonIndexValue() + i];
                cachedNextButtonHandler.Delete();
                cachedNextButtonHandler.currentButton.interactable = true;
            }
        }
    }

    // public void Addx1()
    // {
    //     ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
    //     ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;

    //     if(cachedCurrentButtonHandler != null && buttonHighlight.lastButton != null)
    //     {
    //         cachedCurrentButtonHandler.unit = unitx1;
    //         buttonHighlight.currentButtonUnit = unitx1;
            
    //         cachedLastButtonHandler.unit = unitx1;
    //         buttonHighlight.lastButtonUnit = unitx1;

    //         cachedCurrentButtonHandler.currentImage.sprite = unitx1.unitSprite;
    //         cachedLastButtonHandler.currentImage.sprite = unitx1.unitSprite;
    //     }
    //     else if(buttonHighlight.currentButton != null || buttonHighlight.lastButton != null)
    //     {
    //         cachedCurrentButtonHandler.unit = unitx1;
    //         buttonHighlight.currentButtonUnit = unitx1;
    //         cachedCurrentButtonHandler.currentImage.sprite = unitx1.unitSprite;
    //     }
    // }

    public void Addx1(UnitBase unit)
    {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;

        cachedCurrentButtonHandler?.AddUnit(unit);
        cachedLastButtonHandler?.AddUnit(unit);

    }
    // public void Addx2()
    // {
    //     ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
    //     ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
    //     ButtonHandler cachedNextButtonHandler = buttonHighlight.buttonHandlersCollection[buttonHighlight.currentButton.GetCurrentButtonIndexValue() + 1];

    //     if(cachedCurrentButtonHandler != null && buttonHighlight.lastButton != null)
    //     {
    //         cachedCurrentButtonHandler.unit = unitx2;
    //         buttonHighlight.currentButtonUnit = unitx2;

    //         cachedCurrentButtonHandler.unit = unitx2;
    //         buttonHighlight.lastButtonUnit = unitx2;

    //         cachedCurrentButtonHandler.currentImage.sprite = unitx2.unitSprite;
    //         cachedLastButtonHandler.currentImage.sprite = unitx2.unitSprite;

    //         cachedNextButtonHandler.unit = unitx2;
    //         cachedNextButtonHandler.currentImage.sprite = unitx2.unitSprite;
    //         cachedNextButtonHandler.currentButton.interactable = false;
    //     }
    //     else if(buttonHighlight.currentButton != null || buttonHighlight.lastButton != null)
    //     {
    //         cachedCurrentButtonHandler.unit = unitx2;
    //         buttonHighlight.currentButtonUnit = unitx2;
    //         cachedCurrentButtonHandler.currentImage.sprite = unitx2.unitSprite;

    //         cachedNextButtonHandler.unit = unitx2;
    //         cachedNextButtonHandler.currentImage.sprite = unitx2.unitSprite;
    //         cachedNextButtonHandler.currentButton.interactable = false;
    //     }
    // }

    public void Addx2(UnitBase unit)
    {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;

        cachedCurrentButtonHandler?.AddUnit(unit);
        cachedLastButtonHandler?.AddUnit(unit);
        TryDisableNextUnitSlot(cachedCurrentButtonHandler);
        TryDisableNextUnitSlot(cachedLastButtonHandler);
    }

    public void TryDisableNextUnitSlot(ButtonHandler buttonHandler)
    {
        ButtonHandler cachedNextButtonHandler;

        if(buttonHandler?.unit?.unitSize > 1)
        {
            for(int i = 1 ; i < buttonHandler.unit.unitSize; i++)
            {
                cachedNextButtonHandler = buttonHighlight.buttonHandlersCollection[buttonHandler.GetCurrentButtonIndexValue() + i];
                cachedNextButtonHandler.currentButton.interactable = false;
                cachedNextButtonHandler.AddUnit(buttonHandler.unit);
            }
        }
    }
}
