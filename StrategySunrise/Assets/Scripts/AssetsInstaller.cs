﻿using System;
using Abstractions;
using Abstractions.Commands;
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
        [SerializeField] private SelectableValue _selectables;

        public override void InstallBindings()
        {
            Container.Bind<IAwaitable<IAttackable>>()
                .FromInstance(_attackableClicksRMB);
            Container.Bind<IAwaitable<Vector3>>()
                .FromInstance(_groundClicksRMB);
            Container.Bind<IObservable<ISelectable>>().
                FromInstance(_selectables);
            Container.BindInstances(_legacyContext, _selectables);
        }
    }
}