using Unity.Mathematics;

namespace Jolt
{
    public interface IShape
    {
        /// <summary>
        /// TODO document
        /// </summary>
        public ShapeType GetType();

        /// <summary>
        /// TODO document
        /// </summary>
        public ShapeSubType GetSubType();

        /// <summary>
        /// Get custom user data on the shape.
        /// </summary>
        public ulong GetUserData();

        /// <summary>
        /// Set custom user data on the shape.
        /// </summary>
        public void SetUserData(ulong userData);

        /// <summary>
        /// TODO document
        /// </summary>
        public bool MustBeStatic();

        /// <summary>
        /// Get the shape's center of mass.
        /// </summary>
        public float3 GetCenterOfMass();

        /// <summary>
        /// Get the shape's local bounds.
        /// </summary>
        public AABox GetLocalBounds();

        /// <summary>
        /// TODO document
        /// </summary>
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale);

        /// <summary>
        /// Get the shape's inner radius.
        /// </summary>
        public float GetInnerRadius();

        /// <summary>
        /// Get the shape's mass properties.
        /// </summary>
        public MassProperties GetMassProperties();

        /// <summary>
        /// TODO document
        /// </summary>
        public float3 GetSurfaceNormal(uint subShapeID, float3 localPosition);

        /// <summary>
        /// Get the shape's volume.
        /// </summary>
        public float GetVolume();
    }
}
