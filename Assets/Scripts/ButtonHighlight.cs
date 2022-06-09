using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite buttonImage;
    [SerializeField] Sprite selectedImage;
    public int counter = 0;
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
        // if(counter < 3)
        // {
        //     foreach(Button button in buttons)
        //     {
        //         if(button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
        //             counter++;
        //         else if(button.gameObject.GetComponent<ButtonHandler>().isButtonClicked == true)
        //             counter--;
        //     } 
        // }
     
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
