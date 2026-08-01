using System;
using System.Collections.Generic;

[Serializable]
public class AdventurerPreference
{
    public bool IsLike = true;
    public Class Class;
    public Race Race;
    public Item Item;
    public Personality Personality;

    /// <summary>
    /// Whether the given adventurer matches the traits this preference describes.
    /// Traits left as None are wildcards and are ignored.
    /// Liking/disliking is resolved by <see cref="PreferencesUtilities.IsPreferenceFulfilled"/>, not here.
    /// </summary>
    public bool IsConditionMet(Adventurer adventurer)
    {
        if (Class == Class.None && Race == Race.None && Item == Item.None && Personality == Personality.None)
        {
            return false;
        }
        return TraitMatches((int)adventurer.Class, (int)Class) &&
               TraitMatches((int)adventurer.Race, (int)Race) &&
               TraitMatches((int)adventurer.Item, (int)Item) &&
               TraitMatches((int)adventurer.Personality, (int)Personality);
    }

    private bool TraitMatches(int adventurerValue, int preferenceValue)
    {
        // A preference value of None means "don't care".
        return preferenceValue == 0 || adventurerValue == preferenceValue;
    }

    public override string ToString()
    {
        List<string> conditions = new List<string>();
        if (Class != Class.None)
        {
            conditions.Add(Class.ToString());
        }
        if (Race != Race.None)
        {
            conditions.Add(Race.ToString());
        }
        if (Item != Item.None)
        {
            conditions.Add(Item.ToString());
        }
        if (Personality != Personality.None)
        {
            conditions.Add(Personality.ToString());
        }
        return string.Join(", ", conditions);
    }
}