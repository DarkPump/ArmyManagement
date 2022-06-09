using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite buttonImage;
    [SerializeField] Sprite selectedImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighlightButton();
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
            Debug.Log(button.name + " " + button.gameObject.GetComponent<ButtonHandler>().isButtonClicked);
        }
    }
}
