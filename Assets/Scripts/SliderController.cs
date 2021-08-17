using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    public float sliderSpeed = 0.1f;
    public float maxSpeed = 1.5f;
    public float sliderTimer = 0;
    public void OnSliderChanged(float speedValue)
    {
        if (speedValue <= maxSpeed)
        {
            sliderSpeed += Time.deltaTime;
        }
        else
        {
            sliderTimer = 0f;
        }
        sliderTimer += Time.deltaTime;
    }

}
