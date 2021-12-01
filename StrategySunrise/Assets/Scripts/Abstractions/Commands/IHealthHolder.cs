namespace Abstractions.Commands
{
    public interface IHealthHolder
    {
        float Health { get; }
        float MaxHealth { get; }
    }
}