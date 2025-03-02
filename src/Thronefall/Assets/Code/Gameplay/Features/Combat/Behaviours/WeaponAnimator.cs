using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class WeaponAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Attack = Animator.StringToHash("Attack");

        public void SetIsAttacking(bool isAttacking)
        {
            _animator.SetBool(Attack, isAttacking);
        }
    }
}