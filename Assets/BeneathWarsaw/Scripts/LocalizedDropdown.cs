using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;

public class LocalizedDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<LocalizedString> localizedOptions; // One entry per option

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
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
        dropdown.options.Clear();

        foreach (var locString in localizedOptions)
        {
            var handle = locString.GetLocalizedStringAsync();
            string translated = await handle.Task;
            dropdown.options.Add(new TMP_Dropdown.OptionData(translated));
        }

        // Force UI to update visible label
        dropdown.RefreshShownValue();
    }

}


