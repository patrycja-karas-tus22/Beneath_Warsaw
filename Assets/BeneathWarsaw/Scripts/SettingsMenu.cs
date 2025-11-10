using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown turnTypeDropdown;
    public TMP_Dropdown movementTypeDropdown;
    public GameObject languagePanel;
    public GameObject movementPanel;
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }
    }

    public void LanguageTab()
    {
        languagePanel.SetActive(true);
        movementPanel.SetActive(false);


    }
    public void MovementTab()
    {
        movementPanel.SetActive(true);
        languagePanel.SetActive(false);

    }
    public TMP_Dropdown languageDropdown;

    public void OnLanguageChanged()
    {
        StartCoroutine(SetLanguage(languageDropdown.value));
    }

    IEnumerator SetLanguage(int index)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
    /* public void SetLanguage(int index)
     {
         LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
         RefreshDropdowns();
     }
     void RefreshDropdowns()
     {
         if (turnTypeDropdown != null)
             turnTypeDropdown.RefreshShownValue();

         if (movementTypeDropdown != null)
             movementTypeDropdown.RefreshShownValue();
     }
     /* public void GeneralButtonPress()
      {
          Debug.Log("HIIII");
      }

      */

    void ToggleMenu()
    {
        canvas.enabled = !canvas.enabled;
    }
}

