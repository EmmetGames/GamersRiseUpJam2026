using System.Collections.Generic;
using UnityEngine;

public class TableView : MonoBehaviour, ISelectableView
{
    [SerializeField] private SeatView[] _seats;
    
    public bool Seat(AdventurerView adventurerView)
    {
        List<SeatView> availableSeats = GetAvailableSeats();
        if (availableSeats.Count <= 0)
        {
            return false;
        }
        SeatView seat = availableSeats[Random.Range(0, availableSeats.Count)];
        seat.Seat(adventurerView);
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

    public void Select(ISelectableView previousSelectedView)
    {
        throw new System.NotImplementedException();
    }

    public void Deselect()
    {
        throw new System.NotImplementedException();
    }
}