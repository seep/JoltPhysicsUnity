using UnityEngine;

namespace Jolt.Samples
{
    /// <summary>
    /// Base class to facilitate FindObjectByType.
    /// </summary>
    public abstract class PhysicsConstraintBase : MonoBehaviour
    {
        internal abstract Constraint Initialize(ManagedPhysicsContext context);
    }
}