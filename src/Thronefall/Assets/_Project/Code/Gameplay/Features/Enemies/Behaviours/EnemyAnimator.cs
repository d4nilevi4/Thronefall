using System;
using UnityEngine;

namespace Thronefall.Gameplay.Enemies
{
    public class EnemyAnimator : MonoBehaviour, ITakeDamageAnimator
    {
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

        public void PlayTakeDamage()
        {
            _renderer.sharedMaterial = _takeDamageMat;

            _takeDamage = true;
            _timer = _takeDamageMaxTime;
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
    }
}