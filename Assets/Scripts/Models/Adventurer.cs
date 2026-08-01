using System;
using System.Text;

[Serializable]
public class Adventurer
{
    private Name? _name = null;
    
    public Class Class;
    public Race Race;
    public Item Item;
    public Personality Personality;
    public AdventurerPreference[] Preferences;

    private StringBuilder _stringBuilder = new StringBuilder();
    
    private Name PickRandomName()
    {
        Array names = Enum.GetValues(typeof(Name));
        return (Name)names.GetValue(UnityEngine.Random.Range(0, names.Length));
    }
    
    public Name Name => _name ?? PickRandomName();

    public string DescriptionString()
    {
        _stringBuilder.Clear();
        _stringBuilder.AppendLine($"Class: {Class}");
        _stringBuilder.AppendLine($"Race: {Race}");
        _stringBuilder.AppendLine($"Item: {Item}");
        _stringBuilder.AppendLine($"Personality: {Personality}");
        return _stringBuilder.ToString();
    }
}