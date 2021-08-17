using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public SavePatternMenu savePatternMenu;
    public LoadPatternMenu loadPatternMenu;
    public bool active = false;
    void Start()
    {
        savePatternMenu.gameObject.SetActive(false);
        loadPatternMenu.gameObject.SetActive(false);
    }

    public void ShowSaveMenu()
    {
        savePatternMenu.gameObject.SetActive(true);
        active = true;
    }

    public void ShowLoadMenu()
    {
        loadPatternMenu.gameObject.SetActive(true);
        active = true;
    }
}
