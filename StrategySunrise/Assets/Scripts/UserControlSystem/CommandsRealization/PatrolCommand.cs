using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 Position { get; set; }

        public PatrolCommand(Vector3 positions) => Position = positions;

    }
}