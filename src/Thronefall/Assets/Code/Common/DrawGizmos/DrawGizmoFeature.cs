using System.Collections.Generic;
using Entitas;

namespace Thronefall.Common
{
    public class DrawGizmoFeature : Feature, IDrawGizmoSystem
    {
#if UNITY_EDITOR
        private List<string> _drawGizmosSystemNames = new();
        private List<IDrawGizmoSystem> _drawGizmosSystem = new();
#endif
        public override Systems Add(ISystem system)
        {
#if UNITY_EDITOR
            if (system is IDrawGizmoSystem drawGizmoSystem)
            {
                _drawGizmosSystemNames.Add(system.GetType().FullName);
                _drawGizmosSystem.Add(drawGizmoSystem);
            }
#endif
            return base.Add(system);
        }

        public void DrawGizmo()
        {
#if UNITY_EDITOR
            for (int i = 0; i < _drawGizmosSystem.Count; i++) {
                UnityEngine.Profiling.Profiler.BeginSample(_drawGizmosSystemNames[i]);
                _drawGizmosSystem[i].DrawGizmo();
                UnityEngine.Profiling.Profiler.EndSample();
            }
#endif
        }
    }
}