public static class PreferencesUtilities
{
    public static bool IsPreferenceFulfilled(AdventurerView sourceAdventurerView, TableView tableView, AdventurerPreference preference)
    {
        if (tableView == null)
        {
            return false;
        }

        bool anyMatch = false;
        foreach (AdventurerView adventurerView in tableView.GetAdventurers())
        {
            if (sourceAdventurerView == adventurerView)
            {
                continue;
            }
            if (preference.IsConditionMet(adventurerView.Model))
            {
                anyMatch = true;
                break;
            }
        }

        // A like is fulfilled when someone at the table matches, a dislike when nobody does.
        return preference.IsLike ? anyMatch : !anyMatch;
    }
}
