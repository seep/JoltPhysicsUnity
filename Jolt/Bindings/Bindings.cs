namespace Jolt
{
    internal static partial class Bindings
    {
        public const string ImportName = "joltc";
    }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_Shape pointers.
    /// </summary>
    internal interface INativeShape { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ConvexShape pointers.
    /// </summary>
    internal interface INativeConvexShape { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ShapeSettings pointers.
    /// </summary>
    internal interface INativeShapeSettings { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ConvexShapeSettings pointers.
    /// </summary>
    internal interface INativeConvexShapeSettings { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_CompoundShapeSettings pointers.
    /// </summary>
    internal interface INativeCompoundShapeSettings  { }

    #region Shapes

    internal partial struct JPH_Shape : INativeShape { }

    internal partial struct JPH_ConvexShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_BoxShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_SphereShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_CapsuleShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_CylinderShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_ConvexHullShape : INativeShape, INativeConvexShape { }

    internal partial struct JPH_MeshShape : INativeShape { }

    #endregion

    #region Shape Settings

    internal partial struct JPH_ShapeSettings : INativeShapeSettings { }

    internal partial struct JPH_ConvexShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_BoxShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_SphereShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_CapsuleShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_CylinderShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_ConvexHullShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_MeshShapeSettings : INativeShapeSettings { }

    internal partial struct JPH_TaperedCapsuleShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    internal partial struct JPH_CompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    internal partial struct JPH_StaticCompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    internal partial struct JPH_MutableCompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    #endregion
}
