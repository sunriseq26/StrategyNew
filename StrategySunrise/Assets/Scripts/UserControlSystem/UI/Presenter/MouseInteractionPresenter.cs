using System.Linq;
using Abstractions;
using Abstractions.Commands;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Utils;
using Zenject;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private EventSystem _eventSystem;
    
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private AttackableValue _attackablesRMB;
    
    [Inject] private SelectableValue _selectedObject;
    
    private Plane _groundPlane;
    
    [Inject]
    private void Init()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        var uiFramesStream = Observable.EveryUpdate()
            .Where(_ => !_eventSystem.IsPointerOverGameObject());

        var leftButtonClick = uiFramesStream
            .Where(_ => Input.GetMouseButtonDown(0));
        var rightButtonClick = uiFramesStream
            .Where(_ => Input.GetMouseButtonDown(1));

        var leftButtonRays = leftButtonClick
            .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rightButtonRays = rightButtonClick
            .Select(_ => _camera.ScreenPointToRay(Input.mousePosition));

        var leftButtonHits = leftButtonRays
            .Select(ray => Physics.RaycastAll(ray));
        var rightButtonHits = rightButtonRays
            .Select(ray => (ray, Physics.RaycastAll(ray)));

        leftButtonHits.Subscribe(hits =>
        {
            if (WeHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });
        rightButtonHits.Subscribe((ray, hits) =>
        {
            if (WeHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }

        });
    }


    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }

        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .FirstOrDefault(c => c != null);
        return result != default;
    }
}