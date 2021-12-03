using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.Model;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue: StatelessScriptableObjectValueBase<IAttackable>
    { 
        
    }
}