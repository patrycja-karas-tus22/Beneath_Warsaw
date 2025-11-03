using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
public class SettingsMenu : MonoBehaviour
{
    public void GeneralButtonPress()
    {
        Debug.Log("HIIII");
    }
        public void SetLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}

