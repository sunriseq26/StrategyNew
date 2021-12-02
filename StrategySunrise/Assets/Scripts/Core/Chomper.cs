using Abstractions;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public class Chomper : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        
        private float _health = 500;
    }
}