using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        public string Message { get; set; }

        public AttackCommand(string msg) => Message = msg;
    }
}