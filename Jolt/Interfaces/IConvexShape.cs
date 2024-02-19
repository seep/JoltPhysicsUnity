namespace Jolt
{
    public interface IConvexShape : IShape
    {
        /// <summary>
        /// Get the convex shape's density.
        /// </summary>
        public float GetDensity();

        /// <summary>
        /// Set the convex shape's density.
        /// </summary>
        public void SetDensity(float density);
    }
}
