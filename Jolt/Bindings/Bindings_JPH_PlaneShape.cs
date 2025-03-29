namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        /// <summary>
        /// Create a new plane shape. The negative space is infinite. The plane face is technically infinite but the
        /// half extent restricts the bounding box to optimize collision checks. Planes cannot be on dynamic bodies.
        /// </summary>
        public static NativeHandle<JPH_PlaneShape> JPH_PlaneShape_Create(Plane plane, float halfExtent)
        {
            AssertInitialized();

            // TODO include JPH_PhysicsMaterial argument

            return CreateHandle(UnsafeBindings.JPH_PlaneShape_Create((JPH_Plane*)&plane, default, halfExtent));
        }

        /// <summary>
        /// Get the plane that defines the shape.
        /// </summary>
        public static Plane JPH_PlaneShape_GetPlane(NativeHandle<JPH_PlaneShape> shape)
        {
            AssertInitialized();

            Plane result = default;
            UnsafeBindings.JPH_PlaneShape_GetPlane(shape, (JPH_Plane*)&result);
            return result;
        }

        /// <summary>
        /// Get the half extend that restricts the bounding box of the shape.
        /// </summary>
        public static float JPH_PlaneShape_GetHalfExtent(NativeHandle<JPH_PlaneShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_PlaneShape_GetHalfExtent(shape);
        }
    }
}
