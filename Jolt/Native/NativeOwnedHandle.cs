namespace Jolt
{
    internal unsafe struct NativeOwnedHandle<T> where T : unmanaged
    {
        /// <summary>
        /// The handle of the owner.
        /// </summary>
        internal NativeHandle Owner;

        /// <summary>
        /// The raw pointer to the resource. This pointer is only valid if the handle is valid.
        /// </summary>
        internal T* Resource;
    }
}
