using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private float _maxHealth = 0;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
    }
}