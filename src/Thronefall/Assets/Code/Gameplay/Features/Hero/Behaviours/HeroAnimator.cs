using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int MoveXHash = Animator.StringToHash("Move_X");
        private static readonly int MoveZHash = Animator.StringToHash("Move_Z");
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
       
        public Animator Animator;


        public void PlayMove()
        {
            Animator.SetBool(IsMovingHash, true);
        }

        public void PlayIdle()
        {
            Animator.SetBool(IsMovingHash, false);
        }

        public void SetMoveAxis(float x, float z)
        {
            Animator.SetFloat(MoveXHash, x);
            Animator.SetFloat(MoveZHash, z);
        }
    }
}