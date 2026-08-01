using TMPro;
using UnityEngine;

public class ContextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private GameObject _preferenceParent;
    [SerializeField] private PreferenceFullView _preferenceFullViewPrefab;
    
    public void UpdateView(AdventurerView adventurerView)
    {
        _titleText.text = adventurerView.Model.Name.ToString();
        _descriptionText.text = adventurerView.Model.DescriptionString();
        PopulatePreferences(adventurerView);
    }

    private void PopulatePreferences(AdventurerView adventurerView)
    {
        // Delete all children
        foreach (Transform child in _preferenceParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var preference in adventurerView.Model.Preferences)
        {
            PreferenceFullView preferenceView = Instantiate(_preferenceFullViewPrefab, _preferenceParent.transform);
            preferenceView.UpdateView(preference, PreferencesUtilities.IsPreferenceFulfilled(adventurerView, adventurerView.Table, preference));
        }
    }
}

public static class PreferencesUtilities
{
    public static bool IsPreferenceFulfilled(AdventurerView sourceAdventurerView, TableView tableView, AdventurerPreference preference)
    {
        bool conditionMet = false;
        if (!preference.IsLike)
            conditionMet = true;
        
        foreach (AdventurerView adventurerView in tableView.GetAdventurers())
        {
            if (sourceAdventurerView == adventurerView)
                continue;

            if (preference.IsConditionMet(adventurerView.Model) && preference.IsLike)
            {
                conditionMet = true;
                break;
            }
            if (!preference.IsConditionMet(adventurerView.Model) && !preference.IsLike)
            {
                conditionMet = true;
            }
        }
        return conditionMet;
    }
}