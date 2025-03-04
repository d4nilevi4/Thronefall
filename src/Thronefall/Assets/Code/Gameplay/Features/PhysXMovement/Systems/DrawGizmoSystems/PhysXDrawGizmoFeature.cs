using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.PhysXMovement
{
    public sealed class PhysXDrawGizmoFeature : CustomFeature
    {
        public PhysXDrawGizmoFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DrawVelocityGizmoSystem>());
        }
    }
}