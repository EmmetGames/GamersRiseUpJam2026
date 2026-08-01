using TMPro;
using UnityEngine;

public class ContextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private GameObject _preferenceParent;
    [SerializeField] private PreferenceFullView _preferenceFullViewPrefab;

    public void Initialize(SelectionManager selectionManager)
    {
        selectionManager.OnSelectedViewChanged += UpdateView;
    }

    public void UpdateView(ISelectableView selectedView)
    {
        if (selectedView is AdventurerView adventurerView)
        {
            UpdateView(adventurerView);
        }
        else if (selectedView is TableView tableView)
        {
            UpdateView(tableView);
        }
    }

    public void UpdateView(AdventurerView adventurerView)
    {
        _titleText.text = adventurerView.Model.Name.ToString();
        _descriptionText.text = adventurerView.Model.DescriptionString();
        PopulatePreferences(adventurerView);
    }

    public void UpdateView(TableView tableView)
    {
        _titleText.text = "Table " + (tableView.transform.GetSiblingIndex() + 1);
        _descriptionText.text = "";
        PopulatePreferences(tableView);
    }
    
    private void PopulatePreferences(TableView tableView)
    {
        // Delete all children
        foreach (Transform child in _preferenceParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var adventurerView in tableView.GetAdventurers())
        {
            foreach (var preference in adventurerView.Model.Preferences)
            {
                PreferenceFullView preferenceView = Instantiate(_preferenceFullViewPrefab, _preferenceParent.transform);
                preferenceView.UpdateView(preference,
                    PreferencesUtilities.IsPreferenceFulfilled(adventurerView, adventurerView.Table, preference));
            }
        }
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