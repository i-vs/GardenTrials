using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    protected bool isButtonClicked;

    public bool IsButtonClicked { get => isButtonClicked; set => isButtonClicked = value; }
    // Start is called before the first frame update
    void Start()
    {
        isButtonClicked = false;   
    }
    public void Click()
    {
        isButtonClicked = true;
    }

    public void ResetButton()
    {
        isButtonClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
