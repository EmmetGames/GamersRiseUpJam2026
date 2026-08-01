using System;

public class AdventurerPreference
{
    public bool IsLike;
    public Class? Class;
    public Race? Race;
    public Item? Item;
    public Personality? Personality;

    public bool IsConditionMet(Adventurer adventurer)
    {
        return ConditionMet(adventurer.Class, Class, IsLike) &&
               ConditionMet(adventurer.Race, Race, IsLike) &&
               ConditionMet(adventurer.Item, Item, IsLike) &&
               ConditionMet(adventurer.Personality, Personality, IsLike);
    }
    
    private bool ConditionMet(Object objectOne, Object objectTwo, bool isLike)
    {
        if (isLike && objectOne != null && objectOne == objectTwo)
        {
            return true;
        }
        if (!isLike && objectOne != null && objectOne != objectTwo)
        {
            return true;
        }
        return false;
    }
}