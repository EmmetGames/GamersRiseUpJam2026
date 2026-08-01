using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TableView : MonoBehaviour, ISelectableView
{
    [SerializeField] private SeatView[] _seats;
    
    SelectionManager _selectionManager;

    public void Initialize(SelectionManager selectionManager)
    {
        _selectionManager = selectionManager;
    }
    
    public bool Seat(AdventurerView adventurerView)
    {
        List<SeatView> availableSeats = GetAvailableSeats();
        if (availableSeats.Count <= 0)
        {
            return false;
        }
        SeatView seat = availableSeats[Random.Range(0, availableSeats.Count)];
        seat.Seat(adventurerView);
        adventurerView.SetTableView(this);
        return true;
    }

    private List<SeatView> GetAvailableSeats()
    {
        List<SeatView> availableSeats = new List<SeatView>();
        foreach (SeatView seat in _seats)
        {
            if (seat != null && !seat.IsOccupied)
            {
                availableSeats.Add(seat);
            }
        }
        return availableSeats;
    }
    
    public bool IsFull()
    {
        return GetAvailableSeats().Count <= 0;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        _selectionManager.Clicked(this);
    }

    public void Select(ISelectableView previousSelectedView)
    {
        throw new System.NotImplementedException();
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<AdventurerView> GetAdventurers()
    {
        List<AdventurerView> adventurers = new List<AdventurerView>();
        foreach (SeatView seat in _seats)
        {
            if (seat != null && seat.IsOccupied)
            {
                adventurers.Add(seat.AdventurerView);
            }
        }
        return adventurers;
    }
}