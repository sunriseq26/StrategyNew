using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}