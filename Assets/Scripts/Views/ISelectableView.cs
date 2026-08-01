public interface ISelectableView
{
    public void Select(ISelectableView previousSelectedView);

    public void Deselect();
}