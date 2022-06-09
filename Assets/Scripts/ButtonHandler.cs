using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public bool isButtonClicked = false;
    [SerializeField] public GameObject canvas;
    public void HighlightButton()
    {
        if(canvas.gameObject.GetComponent<ButtonHighlight>().counter < 2)
            isButtonClicked = true;
        else
            isButtonClicked = false;
    }

    public void CountButtons()
    {
        if(canvas.gameObject.GetComponent<ButtonHighlight>().counter < 2 && isButtonClicked == true)
            canvas.gameObject.GetComponent<ButtonHighlight>().counter++;
        else if(canvas.gameObject.GetComponent<ButtonHighlight>().counter > 0 && isButtonClicked == false)
            if(canvas.gameObject.GetComponent<ButtonHighlight>().counter == 2)
                Debug.Log("Max zaznaczenia!");
            else
                canvas.gameObject.GetComponent<ButtonHighlight>().counter--;
            

    }
}
