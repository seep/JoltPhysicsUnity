using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ConvexHullShapeSettings : IEquatable<ConvexHullShapeSettings>
    {
        internal readonly NativeHandle<JPH_ConvexHullShapeSettings> Handle;
        
        internal ConvexHullShapeSettings(NativeHandle<JPH_ConvexHullShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ConvexHullShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConvexHullShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConvexHullShapeSettings
        
        public ConvexHullShape CreateShape() => new ConvexHullShape(Bindings.JPH_ConvexHullShapeSettings_CreateShape(Handle));
        
        #endregion
        
        #region JPH_ConvexShapeSettings
        
        public float GetDensity() => Bindings.JPH_ConvexShapeSettings_GetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>());
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShapeSettings_SetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>(), density);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
    }
}
