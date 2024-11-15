using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class DamageEffect : ISkillEffect
{
    public int Damage { get; private set;}

public DamageEffect(int damage)
{
    Damage = damage;
}

public void Apply(ISkillTarget target)
{
    if(target is PlayerTarget playertarget)
    {
        playertarget.Health -= Damage;
        Debug.Log($"Player took {Damage} damage. Remaining Health : {playertarget.Health}");
    }
    else if (target is EnamyTarget enamyTarget)
    {
        enamyTarget.Health -= Damage;
        Debug.Log($"Player took {Damage} damage, Ramaining health : {enamyTarget.Health}");
    }
}
}
