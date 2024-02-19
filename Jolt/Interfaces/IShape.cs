using Unity.Mathematics;

namespace Jolt
{
    public interface IShape
    {
        /// <summary>
        /// Get the shape's local bounds.
        /// </summary>
        public AABox GetLocalBounds();

        /// <summary>
        /// Get the shape's mass properties.
        /// </summary>
        public MassProperties GetMassProperties();

        /// <summary>
        /// Get the shape's center of mass.
        /// </summary>
        public float3 GetCenterOfMass();

        /// <summary>
        /// Get the shape's inner radius.
        /// </summary>
        public float GetInnerRadius();
    }
}
