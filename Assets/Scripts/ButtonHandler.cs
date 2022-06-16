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
    public int unitSlotID;


    public void HighlightButton()
    {
        if(buttonHighlight.currentButton == null && isButtonClicked == false)
            isButtonClicked = true;
        else if(buttonHighlight.lastButton == null && isButtonClicked == false)
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

    public int GetCurrentUnitSlotID()
    {
        return unitSlotID;
    }

    public void Delete()
    {
        unit = null;
        currentImage.sprite = baseSprite;
    }
    public void AddUnit(UnitBase unitBase)
    {
       unit = unitBase;
       currentImage.sprite = unitBase.unitSprite;
    }
}