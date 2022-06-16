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
    static int lastSlotIndexTop = 5;
    static int lastSlotIndexBottom = 11;
    int unitIndex;

    private void Awake()
    {
        buttonHighlight = canvas.gameObject.GetComponent<ButtonHighlight>();
        int unitsCount = topUnits.Count;
    }

    private void Start() 
    {
        CheckIfUnitsHighlighted();
    }
    private void Update() 
    {
        
    }
    
    public void CheckIfUnitsHighlighted()
    {
        //Swap button
        ValidateAndActivateSwapButton();
        
        //Delete button
        ValidateAndActivateDeleteButton();
        //UnitButton
        ValidateAndActivateUnitButton();
    }

    public void Delete()
    {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
        TryDeleteNextUnitSlot(cachedCurrentButtonHandler);
        TryDeleteNextUnitSlot(cachedLastButtonHandler);
        cachedCurrentButtonHandler?.Delete();
        cachedLastButtonHandler?.Delete();
        CheckIfUnitsHighlighted();
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

    public void Addx1(UnitBase unit)
    {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;

        cachedCurrentButtonHandler?.AddUnit(unit);
        cachedLastButtonHandler?.AddUnit(unit);
        CheckIfUnitsHighlighted();
    }

    public void Addx2(UnitBase unit)
    {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;

        cachedCurrentButtonHandler?.AddUnit(unit);
        cachedLastButtonHandler?.AddUnit(unit);
        TryDisableNextUnitSlot(cachedCurrentButtonHandler);
        TryDisableNextUnitSlot(cachedLastButtonHandler);
        CheckIfUnitsHighlighted();
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

    private void ValidateAndActivateSwapButton() {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
        if((cachedCurrentButtonHandler?.unit || cachedLastButtonHandler?.unit) && (cachedCurrentButtonHandler != null && cachedLastButtonHandler != null))
        {
            swapButton.interactable = true;
        }
        else
        {
            swapButton.interactable = false;
        }

        if(cachedCurrentButtonHandler?.unitSlotID > cachedLastButtonHandler?.unitSlotID)
        {
            if(cachedCurrentButtonHandler.unitSlotID == lastSlotIndexTop || cachedCurrentButtonHandler.unitSlotID == lastSlotIndexBottom)
            {
                swapButton.interactable = false;
            }
        }
        if(cachedCurrentButtonHandler?.unitSlotID < lastSlotIndexTop && cachedLastButtonHandler?.unitSlotID > lastSlotIndexTop)
        {
            if(cachedCurrentButtonHandler.unitSlotID == lastSlotIndexTop || cachedCurrentButtonHandler.unitSlotID == lastSlotIndexBottom)
            {
                swapButton.interactable = false;
            }
        }
    }

    private void ValidateAndActivateDeleteButton() {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
        if(cachedCurrentButtonHandler?.unit || cachedLastButtonHandler?.unit)
        {
            deleteButton.interactable = true;        
        }
        else
        {
            deleteButton.interactable = false;
        }
    }

    private void ValidateAndActivateUnitButton() {
        ButtonHandler cachedCurrentButtonHandler = buttonHighlight.currentButton;
        ButtonHandler cachedLastButtonHandler = buttonHighlight.lastButton;
        if(cachedCurrentButtonHandler == null && cachedLastButtonHandler == null)
        {
            add1Button.interactable = false;
            add2Button.interactable = false;
        }
        else
        {
            add1Button.interactable = true;
            add2Button.interactable = true;
        }

        if(cachedCurrentButtonHandler?.unit != null || cachedLastButtonHandler?.unit != null)
        {
            add1Button.interactable = false;
            add2Button.interactable = false;
        }

        if(cachedCurrentButtonHandler?.unitSlotID == lastSlotIndexTop || cachedCurrentButtonHandler?.unitSlotID == lastSlotIndexBottom 
        || cachedLastButtonHandler?.unitSlotID == lastSlotIndexTop || cachedLastButtonHandler?.unitSlotID == lastSlotIndexBottom)
        {
            add2Button.interactable = false;
        }
        else if(cachedCurrentButtonHandler?.unitSlotID - cachedLastButtonHandler?.unitSlotID == 1 || cachedCurrentButtonHandler?.unitSlotID - cachedLastButtonHandler?.unitSlotID == -1)
        {
            add2Button.interactable = false;
        }

        if(cachedCurrentButtonHandler != null)
        {
            int cachedIndex = cachedCurrentButtonHandler.unitSlotID + 1;

            if(buttonHighlight.buttonHandlersCollection.Length > cachedIndex)
            {
                if(buttonHighlight.buttonHandlersCollection[cachedIndex].unit != null)
                {
                    add2Button.interactable = false;
                }
            }
            
        }
        else if(cachedLastButtonHandler != null)
        {
            int cachedIndex = cachedLastButtonHandler.unitSlotID + 1;
            if(buttonHighlight.buttonHandlersCollection.Length > cachedIndex)
            {
                if(buttonHighlight.buttonHandlersCollection[cachedIndex].unit != null)
                {
                    add2Button.interactable = false;
                }
            }
        }
    }
}
