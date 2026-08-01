using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreferenceFullView : MonoBehaviour
{
    [SerializeField] private Image _preferenceImage;
    [SerializeField] private TMP_Text _preferenceText;
    [SerializeField] private Sprite _goodPreferenceSprite;
    [SerializeField] private Sprite _badPreferenceSprite;

    public void UpdateView(AdventurerPreference preference, bool fulfilled)
    {
        _preferenceImage.sprite = fulfilled ? _goodPreferenceSprite : _badPreferenceSprite;
        _preferenceText.text = preference.ToString();
    }
}