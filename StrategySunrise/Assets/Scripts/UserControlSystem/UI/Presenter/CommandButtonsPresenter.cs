using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
                return;
            }

            var move = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (move != null)
            {
                Vector3 pos = Vector3.zero;
                move.ExecuteSpecificCommand(_context.Inject(new MoveCommand(pos)));
                return;
            }
            
            var patrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patrol != null)
            {
                List<Vector3> wayPoints = new List<Vector3>();
                wayPoints.Add(Vector3.zero);
                foreach (var point in wayPoints)
                {
                    patrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand(point)));
                }
                return;
            }
            
            var attack = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attack != null)
            {
                string msg = "Attack!!!";
                attack.ExecuteSpecificCommand(_context.Inject(new AttackCommand(msg)));
                return;
            }
            
            var stop = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stop != null)
            {
                string msg = "Stop!!!";
                stop.ExecuteSpecificCommand(_context.Inject(new StopCommand(msg)));
                return;
            }
            
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}