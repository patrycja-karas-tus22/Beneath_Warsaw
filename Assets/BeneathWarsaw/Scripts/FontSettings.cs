using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "FontSettings", menuName = "Scriptable Objects/FontSettings")]
public class FontSettings : ScriptableObject
{
    public TMP_FontAsset defaultFont;
    public TMP_FontAsset dyslexicFont;
}
