using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown turnTypeDropdown;
    public TMP_Dropdown movementTypeDropdown;
    public void GeneralButtonPress()
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
    }
}

