using UnityEngine;

public class UiView : MonoBehaviour
{
    [SerializeField] private ContextView _contextView;
    
    public void Initialize(SelectionManager selectionManager)
    {
        _contextView.Initialize(selectionManager);
    }
}