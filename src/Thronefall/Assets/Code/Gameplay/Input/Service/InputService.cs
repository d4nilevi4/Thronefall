using System;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Input
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        private readonly PlayerInput _input;

        public bool HasAxisInput => GetInputAxis().magnitude >= 0.1f;

        public InputService()
        {
            _input = new PlayerInput();
        }

        public void Initialize()
        {
            _input.Enable();
        }

        public Vector2 GetInputAxis() => 
            _input.Gameplay.InputAxis.ReadValue<Vector2>();

        public void Dispose()
        {
            _input.Dispose();
        }
    }
}