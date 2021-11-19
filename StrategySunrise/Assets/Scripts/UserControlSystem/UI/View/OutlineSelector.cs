using UnityEngine;


public sealed class OutlineSelector : MonoBehaviour
{
    [SerializeField] private Outline[] _outlineComponents;

    private bool _isSelectedComponent;
    

    private void Start() => UnOutline();
    
    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedComponent)
        {
            return;
        }

        if (isSelected)
        {
            OnOutline();
        }
        else
        {
            UnOutline();
        }
        
        _isSelectedComponent = isSelected;
    }

    private void UnOutline()
    {
        foreach (var outline in _outlineComponents) outline.enabled = false;
    }

    private void OnOutline()
    {
        foreach (var outline in _outlineComponents) outline.enabled = true;
    }
}
