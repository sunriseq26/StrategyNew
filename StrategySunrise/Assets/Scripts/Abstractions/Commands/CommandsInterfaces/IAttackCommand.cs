using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IAttackCommand : IAttackable, ICommand
    {
        public IAttackable Target { get; }
    }
}