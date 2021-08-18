using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesButton : MonoBehaviour
{
    public HUD hud;
    public void LoadRules()
    {
        //EventManager.TriggerEvent("LoadRules");
        hud.active = false;
        gameObject.SetActive(false);
    }

    public void QuitMenu()
    {
        hud.active = false;
        gameObject.SetActive(false);
    }
}
