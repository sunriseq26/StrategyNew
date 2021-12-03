using System;
using Abstractions;
using UnityEngine;
using Zenject;
using UniRx;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [Inject] private IObservable<ISelectable> _selectableValue;
    
    private OutlineSelector[] _outlineSelectors;
    private ISelectable _currentSelectable;

    private void Start() => _selectableValue.Subscribe(OnSelected);

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable) return;

        Selected(_outlineSelectors, false);
        _outlineSelectors = null;

        if (selectable != null)
        {
            _outlineSelectors = (selectable as Component)?.GetComponentsInParent<OutlineSelector>();
            Selected(_outlineSelectors, true);
        }
        else
        {
            if (_outlineSelectors != null) Selected(_outlineSelectors, false);
            
        }
        
        _currentSelectable = selectable;
        
        static void Selected(OutlineSelector[] selectors, bool value)
        {
            if (selectors == null) return;
            foreach (var selector in selectors) selector.SetSelected(value);
        }
    }
}
