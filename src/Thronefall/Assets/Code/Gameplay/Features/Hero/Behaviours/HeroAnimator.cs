using Thronefall.Gameplay.Enemies;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class HeroAnimator : MonoBehaviour, ITakeDamageAnimator
    {
        private static readonly int MoveXHash = Animator.StringToHash("Move_X");
        private static readonly int MoveZHash = Animator.StringToHash("Move_Z");
        private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
       
        public Animator Animator;
        
        [SerializeField] private Material _takeDamageMat; 
        [SerializeField] private Renderer _renderer; 
        
        private readonly float _takeDamageMaxTime = 0.1f;
        
        private float _timer;
        private bool _takeDamage;
        private Material _defaultMat;

        private void Start()
        {
            _defaultMat = _renderer.sharedMaterial;
        }
        
        public void PlayMove()
        {
            Animator.SetBool(IsMovingHash, true);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_takeDamage && _timer <= 0)
            {
                _renderer.sharedMaterial = _defaultMat;
                _takeDamage = false;
            }
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

        public void PlayTakeDamage()
        {
            _renderer.sharedMaterial = _takeDamageMat;

            _takeDamage = true;
            _timer = _takeDamageMaxTime;
        }
    }
}