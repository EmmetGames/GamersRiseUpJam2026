using System;
using UnityEngine;

public class SelectionManager
{
    ISelectableView _selectedView;
    
    public event Action<ISelectableView> OnSelectedViewChanged;
    
    public void Clicked(ISelectableView selectable)
    {
        Debug.Log("Clicked: " + selectable.ToString());
        ISelectableView previousSelectedView = _selectedView;
        _selectedView = selectable;
        selectable.Select(previousSelectedView);
        previousSelectedView?.Deselect();
        OnSelectedViewChanged?.Invoke(_selectedView);
    }
}