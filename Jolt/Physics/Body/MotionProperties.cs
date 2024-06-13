namespace Jolt
{
    [GenerateHandle("JPH_MotionProperties")]
    public readonly partial struct MotionProperties
    {
        internal readonly NativeHandle<JPH_MotionProperties> Handle;

        internal MotionProperties(NativeHandle<JPH_MotionProperties> handle)
        {
            Handle = handle;
        }
    }
}
