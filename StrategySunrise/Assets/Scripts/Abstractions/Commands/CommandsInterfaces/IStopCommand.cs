﻿namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IStopCommand : ICommand
    {
        string Message { get; set; }
    }
}