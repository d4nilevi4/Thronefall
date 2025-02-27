using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.PhysXMovement
{
    public sealed class PhysXDrawGizmoFeature : DrawGizmoFeature
    {
        public PhysXDrawGizmoFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DrawVelocityGizmoSystem>());
        }
    }
}