using System;

namespace Thronefall.Common
{
    public interface IDrawGizmoReceiver
    {
        event Action EventDrawGizmo;
    }
}