using UnityEngine;

public class UiView : MonoBehaviour
{
    [SerializeField] private ContextView _contextView;
    [SerializeField] private EndgameView _endgameView;

    private LevelManager _levelManager;
    
    public void Initialize(LevelManager levelManager, SelectionManager selectionManager)
    {
        _levelManager = levelManager;
        _contextView.Initialize(selectionManager);
    }
    
    public void ShowEndgame()
    {
        _endgameView.gameObject.SetActive(true);
        _endgameView.Initialize(_levelManager, _levelManager.Tables);
    }
}