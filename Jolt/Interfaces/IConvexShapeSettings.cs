namespace Jolt
{
    public interface IConvexShapeSettings : IShapeSettings
    {
        /// <summary>
        /// Get the shape setting's density.
        /// </summary>
        public float GetDensity();

        /// <summary>
        /// Set the shape setting's density.
        /// </summary>
        public void SetDensity(float density);
    }
}
