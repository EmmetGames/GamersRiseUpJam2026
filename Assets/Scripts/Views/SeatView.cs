using UnityEngine;

public class SeatView : MonoBehaviour
{
    [SerializeField] private Transform _seatTransform;
    
    private AdventurerView _adventurerView = null;
    
    public void Seat(AdventurerView adventurerView)
    {
        _adventurerView = adventurerView;
        _adventurerView.transform.SetParent(_seatTransform);
        _adventurerView.transform.localPosition = Vector3.zero;
    }
    
    public void Unseat()
    {
        _adventurerView = null;
    }
    
    public AdventurerView AdventurerView => _adventurerView;
    
    public bool IsOccupied => _adventurerView != null;
}