using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class LocalizedDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += UpdateDropdownText;
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= UpdateDropdownText;
    }

    private void Start()
    {
        UpdateDropdownText(LocalizationSettings.SelectedLocale);
    }

    private void UpdateDropdownText(Locale locale)
    {
        dropdown.RefreshShownValue();

        // Force rebuild of list so text updates correct
        dropdown.Hide();
    }
}
