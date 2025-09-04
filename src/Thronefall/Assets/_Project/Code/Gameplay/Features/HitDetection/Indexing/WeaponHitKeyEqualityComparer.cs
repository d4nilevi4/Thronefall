using System;
using System.Collections.Generic;

namespace Thronefall.Gameplay.HitDetection
{
    public sealed class WeaponHitKeyEqualityComparer : IEqualityComparer<WeaponHitKey>
    {
        public bool Equals(WeaponHitKey x, WeaponHitKey y)
        {
            return x.WeaponId == y.WeaponId;
        }

        public int GetHashCode(WeaponHitKey obj)
        {
            return HashCode.Combine(obj.WeaponId);
        }
    }
}