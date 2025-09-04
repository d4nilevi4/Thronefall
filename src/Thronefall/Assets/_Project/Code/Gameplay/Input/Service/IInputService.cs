using UnityEngine;

namespace Thronefall.Gameplay.Input
{
    public interface IInputService
    {
        bool HasAxisInput { get; }
        Vector2 GetInputAxis();
    }
}