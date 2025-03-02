namespace Jolt
{
    /// <summary>
    /// Motion type of a physics body.
    /// </summary>
    public enum MotionType : uint
    {
        /// <summary>
        /// Non-movable
        /// </summary>
        Static = 0,

        /// <summary>
        /// Movable using velocities only, does not respond to forces.
        /// </summary>
        Kinematic = 1,

        /// <summary>
        /// Responds to forces as a normal physics object.
        /// </summary>
        Dynamic = 2,
    }
}
