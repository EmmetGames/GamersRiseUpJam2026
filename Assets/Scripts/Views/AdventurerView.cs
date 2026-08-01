using UnityEngine;

public class AdventurerView : MonoBehaviour
{
    [SerializeField] private Adventurer _adventurer;

    public void Initialize(Adventurer adventurer)
    {
        _adventurer = adventurer;
    }
}