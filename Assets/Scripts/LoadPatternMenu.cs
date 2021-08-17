using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadPatternMenu : MonoBehaviour
{
    public Dropdown dropDownMenu;
    public HUD hud;

    void Start()
    {
        ReloadMenu();   // scene first time
    }

    private void OnEnable()  // inherited method
    {
        ReloadMenu();
    }

    void ReloadMenu()
    {
        List<string> options = new List<string>();

        string[] filePaths = Directory.GetFiles(@"gardenpatterns\");

        for (int i = 0; i < filePaths.Length; i++)
        {
            string filename = filePaths[i].Substring(filePaths[i].LastIndexOf("\\") + 1);
            string extension = System.IO.Path.GetExtension(filename);
            filename = filename.Substring(0, filename.Length - extension.Length);
            options.Add(filename);
        }
        dropDownMenu.ClearOptions();
        dropDownMenu.AddOptions(options);
    }

    public void LoadPattern()
    {
        EventManager.TriggerEvent("LoadPattern");
        hud.active = false;
        gameObject.SetActive(false);
    }    
    
    public void QuitMenu()
    {
        hud.active = false;
        gameObject.SetActive(false);
    }
}
