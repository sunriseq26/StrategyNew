using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}