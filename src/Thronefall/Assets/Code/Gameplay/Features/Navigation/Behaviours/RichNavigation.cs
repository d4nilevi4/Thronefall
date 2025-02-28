using System;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Navigation
{
    public class RichNavigation : RichAI
    {
        private Vector2 _currentDirection;
        private bool _lastReachedDestination;

        public event Action EventReachedDestination;

        public Vector2 CurrentDirection => _currentDirection;

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
            if (shouldRecalculatePath) SearchPath();
            
            MovementUpdate(deltaTime, out var nextPosition, out _);
        
            _currentDirection = (nextPosition - transform.position);
            _currentDirection.y = 0;
            _currentDirection.Normalize();
        
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