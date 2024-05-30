using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct ConstraintSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_ConstraintSettings> Handle;

        internal ConstraintSettings(NativeHandle<JPH_ConstraintSettings> handle)
        {
            Handle = handle;
        }

        public void Dispose()
        {
            JPH_ConstraintSettings_Destroy(Handle);
        }
    }
}
