using UnityEngine;
using UserControlSystem;
using Zenject;

namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AssetsInstaller), menuName = "Installers/AssetsInstaller")]
    public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackableClicksRMB;
        [SerializeField] private SelectableValue _selectable;

        public override void InstallBindings() =>
            Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectable);
    }
}