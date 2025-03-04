using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.GroundDetection
{
    public sealed class GroundDetectionFeature : CustomFeature
    {
        public GroundDetectionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<GroundDetectionSystem>());
            
            Add(systemFactory.Create<DrawGroundNormalGizmoSystem>());
            Add(systemFactory.Create<DrawSphereCastGizmoSystem>());
        }
    }
}