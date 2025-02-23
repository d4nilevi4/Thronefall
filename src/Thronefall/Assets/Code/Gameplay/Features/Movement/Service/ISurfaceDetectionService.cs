using UnityEngine;

namespace Thronefall.Gameplay.Movement
{
    public interface ISurfaceDetectionService
    {
        /// <summary>
        /// Checks for the presence of a surface below the given position and returns its normal.
        /// </summary>
        /// <param name="origin">The starting point of the Raycast.</param>
        /// <param name="normal">The output surface normal.</param>
        /// <returns>True if a surface is found, otherwise false.</returns>
        bool TryGetSurfaceNormal(Vector3 origin, out Vector3 normal);
    }
}