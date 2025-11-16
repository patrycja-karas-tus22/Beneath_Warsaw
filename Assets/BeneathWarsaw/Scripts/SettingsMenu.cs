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
    public GameObject accessibilityPanel;
    private Canvas canvas;
    public FontSettings fontSettings;
    public bool useDyslexicFont = false;

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
        accessibilityPanel.SetActive(false);


    }
    public void MovementTab()
    {
        movementPanel.SetActive(true);
        languagePanel.SetActive(false);
        accessibilityPanel.SetActive(false);

    }

    public void AccessibilityTab()
    {
        accessibilityPanel.SetActive(true);
        movementPanel.SetActive(false);
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
    void ToggleMenu()
    {
        canvas.enabled = !canvas.enabled;
    }
        public void ToggleDyslexicFont(bool value)
        {
            useDyslexicFont = value;
            UpdateAllTextElements();
        }

        private void UpdateAllTextElements()
        {
        TMP_Text[] allTexts = FindObjectsByType<TMP_Text>(
     FindObjectsInactive.Include,
     FindObjectsSortMode.None
 );

        TMP_FontAsset targetFont = useDyslexicFont ?
                fontSettings.dyslexicFont :
                fontSettings.defaultFont;

            foreach (TMP_Text text in allTexts)
            {
                text.font = targetFont;
            }
        }
    
}

