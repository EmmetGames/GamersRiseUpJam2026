using System;

[Serializable]
public class AdventurerPreference
{
    public bool IsLike = true;
    public Class Class;
    public Race Race;
    public Item Item;
    public Personality Personality;

    public bool IsConditionMet(Adventurer adventurer)
    {
        return ConditionMet((int)adventurer.Class, (int)Class, IsLike) &&
               ConditionMet((int)adventurer.Race, (int)Race, IsLike) &&
               ConditionMet((int)adventurer.Item, (int)Item, IsLike) &&
               ConditionMet((int)adventurer.Personality, (int)Personality, IsLike);
    }
    
    private bool ConditionMet(int val1, int val2, bool isLike)
    {
        if (isLike && val1 != 0 && val1 == val2)
        {
            return true;
        }
        if (!isLike && val1 != 0 && val1 != val2)
        {
            return true;
        }
        return false;
    }
}