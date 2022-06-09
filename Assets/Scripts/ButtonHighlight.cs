using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite buttonImage;
    [SerializeField] Sprite selectedImage;
    int counter = 0;
    int oldCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighlightButton();
        Debug.Log(counter);
    }
    
    public void CountPressedButtons()
    {
        if(counter == 2)
            Debug.Log("WIECEJ NIZ 2");
        else
        {
            foreach(Button button in buttons)
            {
                if(button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true && counter <= 2)
                    counter++;
            }
        }

        
    }
    public void HighlightButton()
    {
        foreach(Button button in buttons)
        {
            if(button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
            {
                button.image.sprite = selectedImage;
            
            }
            else
            {
                button.image.sprite = buttonImage;

            }
        }
    }
}
