using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace UserControlSystem.CommandsRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public float Health { get; }
        public float MaxHealth { get; }
        public IAttackable Target { get; }

        public AttackCommand(IAttackable target) => Target = target;
    }
}