using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    public ButtonHandler[] buttonHandlersCollection;
    public List<UnitBase> cachedButtonCollection = new List<UnitBase>();
    public ButtonHandler lastButton = null;
    public ButtonHandler currentButton = null;
    public UnitBase lastButtonUnit = null;
    public UnitBase currentButtonUnit = null;
    
    // Start is called before the first frame update
    void Start()
    {
        ButtonInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        HighlightButton();
    }

    public void ButtonInitialize()
    {
        for(int i = 0; i < buttonHandlersCollection.Length; i++)
        {
            buttonHandlersCollection[i].AssignButtonIndex(i);
            buttonHandlersCollection[i].unitSlotID = i;
        }
    }

    public void ReorderObjectsForSwap()
    {
        int cachedCurrentUnitSlotID = currentButton.unitSlotID;
        int cachedLastUnitSlotID = lastButton.unitSlotID;
        cachedButtonCollection = new List<UnitBase>();

        if(lastButton.unitSlotID > currentButton.unitSlotID)
        {
            for(int i = lastButton.unitSlotID; i >= currentButton.unitSlotID; i--)
            {
                if(buttonHandlersCollection[i].currentButton.interactable == false)
                {
                    continue;
                }
                cachedButtonCollection.Add(buttonHandlersCollection[i].unit);
                TryDeleteNextUnitSlot(buttonHandlersCollection[i]);
                buttonHandlersCollection[i].Delete();
            }
            AddSwappedCollection(cachedCurrentUnitSlotID);
            UnselectUnitSlots();
        }
        else
        {
            for(int i = lastButton.unitSlotID; i <= currentButton.unitSlotID; i++)
            {
                cachedButtonCollection.Add(buttonHandlersCollection[i].unit);
                TryDeleteNextUnitSlot(buttonHandlersCollection[i]);
                buttonHandlersCollection[i].Delete();
            }
            cachedButtonCollection.Reverse();
            AddSwappedCollection(cachedLastUnitSlotID);
            UnselectUnitSlots();
        }
    }

    public void TryDeleteNextUnitSlot(ButtonHandler buttonHandler)
    {
        ButtonHandler cachedNextButtonHandler;

        if(buttonHandler?.unit?.unitSize == 2)
        {
            cachedNextButtonHandler = buttonHandlersCollection[buttonHandler.GetCurrentButtonIndexValue() + 1];
            cachedNextButtonHandler.Delete();
            cachedNextButtonHandler.currentButton.interactable = true;
        }
    }

    public void AddSwappedCollection(int startIndexValue)
    {
        int cachedSlotValue = startIndexValue;
        for(int i = 0; i < cachedButtonCollection.Count; i++)
        {
            if(cachedButtonCollection[i]?.unitSize == 2)
            {
                buttonHandlersCollection[cachedSlotValue].AddUnit(cachedButtonCollection[i]);
                TryDisableNextUnitSlot(buttonHandlersCollection[cachedSlotValue]);
                cachedSlotValue += 2;
            }
            else if(cachedButtonCollection[i]?.unitSize == 1)
            {
                buttonHandlersCollection[cachedSlotValue].AddUnit(cachedButtonCollection[i]);
                cachedSlotValue++;
            }
            else
            {
                Debug.Log("Trying to add empty unit, skipping!");
                cachedSlotValue++;
            }
        }
    }

    public void TryDisableNextUnitSlot(ButtonHandler buttonHandler)
    {
        ButtonHandler cachedNextButtonHandler;

        if(buttonHandler?.unit?.unitSize == 2)
        {
                cachedNextButtonHandler = buttonHandlersCollection[buttonHandler.GetCurrentButtonIndexValue() + 1];
                cachedNextButtonHandler.currentButton.interactable = false;
                cachedNextButtonHandler.AddUnit(buttonHandler.unit);
        }
    }



    public void CheckButtons(ButtonHandler buttonHandler)
    {
        if(currentButton == null && buttonHandler.isButtonClicked == true)
        {
            currentButtonUnit = buttonHandler.unit;
            currentButton = buttonHandler;
        }
        else if(currentButton != null && buttonHandler.isButtonClicked == true)
        {
            lastButton = currentButton;
            currentButton = buttonHandler;

            lastButtonUnit = currentButtonUnit;
            currentButtonUnit =  buttonHandler.unit;
        }
        else if((currentButton != null && lastButton != null) && (buttonHandler != currentButton && buttonHandler != lastButton))
        {
            lastButton.isButtonClicked = false;
            buttonHandler.isButtonClicked = true;

            lastButton = currentButton;
            currentButton = buttonHandler;

            lastButtonUnit = currentButtonUnit;
            currentButtonUnit = buttonHandler.unit;
            
        }
        else if(currentButton == buttonHandler && buttonHandler.isButtonClicked == false)
        {
            currentButton = lastButton;
            lastButton = null;

            currentButtonUnit = lastButtonUnit;
            lastButtonUnit = null;
        }
        else if(lastButton == buttonHandler && buttonHandler.isButtonClicked == false)
        {
            lastButton = null;
            lastButtonUnit = null;
        }
    }
    public void HighlightButton()
    {
        for(int i = 0; i < buttonHandlersCollection.Length; i++)
        {
            if(buttonHandlersCollection[i].isButtonClicked == true)
            {
                buttonHandlersCollection[i].highlighter.SetActive(true);
            }
            else
            {
                buttonHandlersCollection[i].highlighter.SetActive(false);
            }
        }
    }

    public void UnselectUnitSlots()
    {
        currentButton.isButtonClicked = false;
        lastButton.isButtonClicked = false;
        currentButton = null;
        lastButton = null;
        HighlightButton();
    }
}
