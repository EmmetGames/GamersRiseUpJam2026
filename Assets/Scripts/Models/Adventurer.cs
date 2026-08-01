using System;

[Serializable]
public class Adventurer
{
    private Name? _name = null;
    
    public Class Class;
    public Race Race;
    public Item Item;
    public Personality Personality;

    private Name PickRandomName()
    {
        Array names = Enum.GetValues(typeof(Name));
        return (Name)names.GetValue(UnityEngine.Random.Range(0, names.Length));
    }
    
    public Name Name => _name ?? PickRandomName();
}

public enum Name
{
    Sam,
    Emmet,
    Evie,
    Sankha,
    Andrew,
    Conor,
    Elyssa,
    Yoni,
    Michael,
    Obama
}