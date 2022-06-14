using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    public ButtonHandler[] buttonHandlersCollection;
    [SerializeField] GameObject topUnitSlotsContainer;
    [SerializeField] GameObject bottomUnitSlotsContainer;

    public ButtonHandler lastButton;
    public ButtonHandler currentButton;
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
        }
    }

    public void CheckButtons(ButtonHandler buttonHandler)
    {
        if(currentButton == null && buttonHandler.isButtonClicked == true)
        {
            currentButtonUnit =  buttonHandler.unit;
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
}
