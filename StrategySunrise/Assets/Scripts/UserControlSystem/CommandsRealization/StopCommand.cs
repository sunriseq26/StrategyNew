using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class StopCommand : IStopCommand
    {
        public string Message { get; set; }

        public StopCommand(string msg) => Message = msg;
    }
}