using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SavePatternMenu : MonoBehaviour
{
    public InputField patternNameField;
    public HUD hud;

    public void SavePattern()
    {
        EventManager.TriggerEvent("SavePattern");
        hud.active = false;
        gameObject.SetActive(false);
        // todo: pause
    }

    public void QuitMenu()
    {
        hud.active = false;
        gameObject.SetActive(false);
    }
}

