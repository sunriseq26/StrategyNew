﻿using Abstractions;
using UnityEngine;

namespace Core
{
    public class Chomper : MonoBehaviour, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
    }
}