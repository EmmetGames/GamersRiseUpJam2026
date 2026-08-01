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