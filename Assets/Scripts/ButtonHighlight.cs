using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    public GameObject lastButton;
    public GameObject currentButton;
    public GameObject lastButtonNext;
    public UnitBase lastButtonUnit = null;
    public GameObject currentButtonNext;
    public UnitBase currentButtonUnit = null;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HighlightButton();
    }

    public void checkButtons(Button button)
    {
        Transform nextChild = this.NextChild();
        if(currentButton == null && button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
        {
            currentButtonUnit =  button.gameObject.GetComponent<ButtonHandler>().unit;
            currentButton = button.gameObject;
            if(nextChild == null)
                Debug.LogFormat("{0} is the last sequential child or didn't have a parent!", this.name);
            else
                Debug.LogFormat ("{0} has a next sequential child named {1}!", this.name, nextChild.name);
        }
        else if(currentButton != null && button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
        {
            lastButton = currentButton;
            currentButton = button.gameObject;

            lastButtonUnit = currentButtonUnit;
            currentButtonUnit =  button.gameObject.GetComponent<ButtonHandler>().unit;
        }
        else if(currentButton == button.gameObject && button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == false)
        {
            currentButton = lastButton;
            lastButton = null;

            currentButtonUnit = lastButtonUnit;
            lastButtonUnit = null;
        }
        else if(lastButton == button.gameObject && button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == false)
        {
            lastButton = null;
            lastButtonUnit = null;
        }
    }
    public void HighlightButton()
    {
        foreach(Button button in buttons)
        {
            if(button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
                button.transform.GetChild(0).gameObject.SetActive(true);
            else
                button.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private Transform NextChild()
    {
        int thisIndex = this.transform.GetSiblingIndex();
        if(this.transform.parent == null)
            return null;
        if(this.transform.parent.childCount <= thisIndex + 1)
            return null;

        return this.transform.parent.GetChild(thisIndex + 1);
    }
}
