using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TableView : MonoBehaviour, ISelectableView
{
    [SerializeField] private SeatView[] _seats;
    [SerializeField] private GameObject _selectedGameObject;
    
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
        adventurerView.Table?.Unseat(adventurerView);
        seat.Seat(adventurerView);
        adventurerView.SetTableView(this);
        return true;
    }

    private void Unseat(AdventurerView adventurerView)
    {
        foreach (SeatView seat in _seats)
        {
            if (seat != null && seat.AdventurerView == adventurerView)
            {
                seat.Unseat();
                break;
            }
        }
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
        if (previousSelectedView is AdventurerView adventurerView)
        {
            Seat(adventurerView);
        }
        _selectedGameObject.SetActive(true);
    }

    public void Deselect()
    {
        _selectedGameObject.SetActive(false);
    }

    public List<AdventurerView> GetAdventurers()
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

    public string GetAdventurerNames()
    {
        string returnString = "";
        var adventurers = GetAdventurers();
        if (adventurers.Count <= 0)
            return returnString;
        
        returnString = adventurers[0].Model.Name.ToString();
        for (int i = 1; i < adventurers.Count - 2; i++)
        {
            returnString += ", ";
            returnString += adventurers[i].Model.Name.ToString();
        }

        if (adventurers.Count > 1)
        {
            returnString += " and ";
            returnString += adventurers[^1].Model.Name.ToString();
        }

        return returnString;
    }

    public int CalculateScore()
    {
        int score = 0;
        
        foreach (var adventurerView in GetAdventurers())
        {
            foreach (var preference in adventurerView.Model.Preferences)
            {
                bool preferenceFulfilled =
                    PreferencesUtilities.IsPreferenceFulfilled(adventurerView, adventurerView.Table, preference);
                Debug.Log(adventurerView.Model.Name + " " + preference.ToString() + " " + preferenceFulfilled);
                score += preferenceFulfilled
                    ? 10
                    : -10;
            }
        }
        return score;
    }
}