using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;

public class LocalizedDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<LocalizedString> localizedOptions; //list of localized string entries, snap and smooth rotate

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged; //if local changes, run 'on locale changed'
        RefreshDropdown();
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    private void OnLocaleChanged(Locale locale)
    {
        RefreshDropdown();
    }

    public async void RefreshDropdown()
    {
        dropdown.options.Clear(); //clear previous text

        foreach (var locString in localizedOptions) //loops through the list options
        {
            var handle = locString.GetLocalizedStringAsync();
            string translated = await handle.Task;
            dropdown.options.Add(new TMP_Dropdown.OptionData(translated)); //adds translated words
        }

        // Force UI to update visible label
        dropdown.RefreshShownValue();
    }

}


