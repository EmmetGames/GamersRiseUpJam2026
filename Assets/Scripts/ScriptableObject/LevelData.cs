using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Adventurer[] _adventurers;
    
    public Adventurer[] Adventurers => _adventurers;
}
