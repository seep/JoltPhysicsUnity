using System;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct Body : IEquatable<Body>
    {
        internal NativeHandle<JPH_Body> Handle;

        internal Body(NativeHandle<JPH_Body> handle)
        {
            Handle = handle;
        }

        public BodyID GetID()
        {
            return JPH_Body_GetID(Handle);
        }

        public BodyType GetBodyType()
        {
            return JPH_Body_GetBodyType(Handle);
        }

        public AABox GetBodyWorldSpaceBounds()
        {
            return JPH_Body_GetWorldSpaceBounds(Handle);
        }

        #region IEquatable

        public bool Equals(Body other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is Body other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
