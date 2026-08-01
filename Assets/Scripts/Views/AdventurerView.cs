using System;
using UnityEngine;

public class AdventurerView : MonoBehaviour, ISelectableView
{
    [SerializeField] private Adventurer _adventurer;
    [SerializeField] private GameObject _selectedGameObject;
    [SerializeField] private PlayerVisualPopulate _playerVisualPopulator;

    private TableView _tableView;
    SelectionManager _selectionManager;

    public void Initialize(Adventurer adventurer, SelectionManager selectionManager)
    {
        _adventurer = adventurer;
        _selectionManager = selectionManager;
        _playerVisualPopulator.PopulateVisuals(_adventurer.Class);
    }
    
    public void SetTableView(TableView tableView)
    {
        _tableView = tableView;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        _selectionManager.Clicked(this);
    }

    public void Select(ISelectableView previousSelectedView)
    {
        _selectedGameObject.SetActive(true);
    }

    public void Deselect()
    {
        _selectedGameObject.SetActive(false);
    }
    
    public Adventurer Model => _adventurer;
    public TableView Table => _tableView;
}