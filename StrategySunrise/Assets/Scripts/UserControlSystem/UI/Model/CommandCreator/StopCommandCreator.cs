using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            throw new NotImplementedException();
        }
    }
}