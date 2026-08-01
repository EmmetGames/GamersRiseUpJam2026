using System;
using UnityEngine;

public class AdventurerView : MonoBehaviour, ISelectableView
{
    [SerializeField] private Adventurer _adventurer;
    
    SelectionManager _selectionManager;

    public void Initialize(Adventurer adventurer, SelectionManager selectionManager)
    {
        _adventurer = adventurer;
        _selectionManager = selectionManager;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        _selectionManager.Clicked(this);
    }

    public void Select(ISelectableView previousSelectedView)
    {
        throw new NotImplementedException();
    }

    public void Deselect()
    {
        throw new NotImplementedException();
    }
}