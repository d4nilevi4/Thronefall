using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int MoveHash = Animator.StringToHash("Move");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int MoveXHash = Animator.StringToHash("Move_X");
        private static readonly int MoveZHash = Animator.StringToHash("Move_Z");
       
        public Animator Animator;


        public void PlayMove()
        {
            Animator.SetTrigger(MoveHash);
        }

        public void PlayIdle()
        {
            Animator.SetTrigger(IdleHash);
        }

        public void SetMoveAxis(float x, float z)
        {
            Animator.SetFloat(MoveXHash, x);
            Animator.SetFloat(MoveZHash, x);
        }
    }
}