namespace Jolt
{
    public enum AllowedDOFs : uint
    {
        /// <summary>
        /// All degrees of freedom are allowed.
        /// </summary>
        All = 0b111111,

        /// <summary>
        /// Body can move in world space X axis.
        /// </summary>
        TranslationX = 0b000001,

        /// <summary>
        /// Body can move in world space Y axis.
        /// </summary>
        TranslationY = 0b000010,

        /// <summary>
        /// Body can move in world space Z axis.
        /// </summary>
        TranslationZ = 0b000100,

        /// <summary>
        /// Body can rotate around local space X axis.
        /// </summary>
        RotationX = 0b001000,

        /// <summary>
        /// Body can rotate around local space Y axis.
        /// </summary>
        RotationY = 0b010000,

        /// <summary>
        /// Body can rotate around local space Z axis.
        /// </summary>
        RotationZ = 0b100000,

        /// <summary>
        /// Body can only move in world space X and Y axis and rotate around local space Z axis.
        /// </summary>
        Plane2D = TranslationX | TranslationY | RotationZ,
    }
}
