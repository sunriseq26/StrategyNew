using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}