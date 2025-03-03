using System;
using System.Linq;
using System.Text;
using Entitas;
using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Enemies;
using Thronefall.Gameplay.Hero;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
    private EntityPrinter _printer;

    public override string ToString()
    {
        if (_printer == null)
            _printer = new EntityPrinter(this);

        _printer.InvalidateCache();

        return _printer.BuildToString();
    }

    public string EntityName(IComponent[] components)
    {
        try
        {
            if (components.Length == 1)
                return components[0].GetType().Name;

            foreach (IComponent component in components)
            {
                switch (component.GetType().Name)
                {
                    case nameof(Hero):
                        return PrintHero();
                    case nameof(WeaponTypeIdComponent):
                        return PrintWeapon();
                    case nameof(EnemyTypeIdComponent):
                        return PrintEnemy();
                }
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(exception.Message);
        }

        return components.First().GetType().Name;
    }

    private string PrintEnemy()
    {
        return new StringBuilder($"Enemy ")
            .Append($"{EnemyTypeId} ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintWeapon()
    {
        return new StringBuilder($"Weapon ")
            .Append($"{WeaponTypeId} ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    private string PrintHero()
    {
        return new StringBuilder($"Hero ")
            .With(s => s.Append($"Id:{Id}"), when: hasId)
            .ToString();
    }

    public string BaseToString() => base.ToString();
}