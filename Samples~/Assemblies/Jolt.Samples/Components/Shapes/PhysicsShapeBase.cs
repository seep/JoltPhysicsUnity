using UnityEngine;

namespace Jolt.Samples
{
    /// <summary>
    /// Base class to facilitate FindObjectByType.
    /// </summary>
    public abstract class PhysicsShapeBase : MonoBehaviour
    {
        internal abstract ShapeSettings CreateShapeSettings();
    }
}