using System;

namespace Jolt
{
    public readonly struct ConstraintSettings : IDisposable, IEquatable<ConstraintSettings>
    {
        internal NativeHandle<JPH_ConstraintSettings> Handle;

        internal ConstraintSettings(NativeHandle<JPH_ConstraintSettings> handle)
        {
            Handle = handle;
        }
    }
}
