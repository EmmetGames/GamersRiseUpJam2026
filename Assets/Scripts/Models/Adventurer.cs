using System;

[Serializable]
public class Adventurer
{
    private Name? _name = null;
    
    public Class Class;
    public Race Race;
    public Item Item;
    public Personality Personality;
    public AdventurerPreference[] Preferences;

    private Name PickRandomName()
    {
        Array names = Enum.GetValues(typeof(Name));
        return (Name)names.GetValue(UnityEngine.Random.Range(0, names.Length));
    }
    
    public Name Name => _name ?? PickRandomName();
}