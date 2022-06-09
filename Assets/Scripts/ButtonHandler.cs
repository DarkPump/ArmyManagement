using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public bool isButtonClicked = false;
    public void HighlightButton()
    {
        isButtonClicked = !isButtonClicked;
    }
}
