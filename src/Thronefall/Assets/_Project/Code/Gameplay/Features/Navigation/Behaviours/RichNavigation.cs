using System;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Navigation
{
    public class RichNavigation : RichAI
    {
        private bool _lastReachedDestination;

        public event Action EventReachedDestination;

        public Vector3 CurrentDirection { get; private set; }

        [Inject]
        private void Construct()
        {
            // _body = GetComponent<ApeCharacterBody>();
        
            radius = 1;//_body.BodySize.x / 2;
            height = 1;//_body.BodySize.y;
            
            _lastReachedDestination = reachedDestination;
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            if (shouldRecalculatePath) 
                SearchPath();
            
            MovementUpdate(deltaTime, out var nextPosition, out _);

            Vector3 direction = nextPosition - transform.position;
            direction.y = 0;
            CurrentDirection = direction.normalized;
            
            CheckReachedDestination();
        }
        
        private void CheckReachedDestination()
        {
            if (_lastReachedDestination != reachedDestination && reachedDestination)
            {
                EventReachedDestination?.Invoke();
            }
        
            _lastReachedDestination = reachedDestination;
        }
    }
}