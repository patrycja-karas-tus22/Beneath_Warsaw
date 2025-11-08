using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
using UnityEngine.InputSystem;
public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown turnTypeDropdown;
    public TMP_Dropdown movementTypeDropdown;
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
   /* public void GeneralButtonPress()
    {
        Debug.Log("HIIII");
    }
        public void SetLanguage(int index)
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
    } */

    void ToggleMenu()
    {
        canvas.enabled = !canvas.enabled;
    }
}

