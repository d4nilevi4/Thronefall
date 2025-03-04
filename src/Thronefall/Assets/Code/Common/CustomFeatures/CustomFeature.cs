using System.Collections.Generic;
using Entitas;

namespace Thronefall.Common
{
    public class CustomFeature : Feature, IDrawGizmoSystem, IFixedExecuteSystem
    {
#if UNITY_EDITOR
        private readonly List<string> _drawGizmosSystemNames = new();
        private readonly List<IDrawGizmoSystem> _drawGizmosSystem = new();
        
        private readonly List<string> _fixedExecuteSystemNames = new();
        private readonly List<IFixedExecuteSystem> _fixedExecuteSystem = new();
#endif
        public override Systems Add(ISystem system)
        {
#if UNITY_EDITOR
            if (system is IDrawGizmoSystem drawGizmoSystem)
            {
                _drawGizmosSystemNames.Add(system.GetType().FullName);
                _drawGizmosSystem.Add(drawGizmoSystem);
            }
            
            if (system is IFixedExecuteSystem fixedExecuteSystem)
            {
                _fixedExecuteSystemNames.Add(system.GetType().FullName);
                _fixedExecuteSystem.Add(fixedExecuteSystem);
            }
#endif
            return base.Add(system);
        }

        public void DrawGizmo()
        {
#if UNITY_EDITOR
            for (int i = 0; i < _drawGizmosSystem.Count; i++)
            {
                UnityEngine.Profiling.Profiler.BeginSample(_drawGizmosSystemNames[i]);
                _drawGizmosSystem[i].DrawGizmo();
                UnityEngine.Profiling.Profiler.EndSample();
            }
#endif
        }
        
        public void FixedExecute()
        {
#if UNITY_EDITOR
            for (int i = 0; i < _fixedExecuteSystem.Count; i++)
            {
                UnityEngine.Profiling.Profiler.BeginSample(_fixedExecuteSystemNames[i]);
                _fixedExecuteSystem[i].FixedExecute();
                UnityEngine.Profiling.Profiler.EndSample();
            }
#endif
        }
    }
}