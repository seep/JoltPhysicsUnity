using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ConvexHullShapeSettings : IEquatable<ConvexHullShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(ConvexHullShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConvexHullShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConvexHullShapeSettings
        
        public ConvexHullShape CreateShape() => new ConvexHullShape { Handle = Bindings.JPH_ConvexHullShapeSettings_CreateShape(Handle) };
        
        #endregion
        
        #region JPH_ConvexShapeSettings
        
        public float GetDensity() => Bindings.JPH_ConvexShapeSettings_GetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>());
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShapeSettings_SetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>(), density);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public ulong GetUserData() => Bindings.JPH_ShapeSettings_GetUserData(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public void SetUserData(ulong data) => Bindings.JPH_ShapeSettings_SetUserData(Handle.Reinterpret<JPH_ShapeSettings>(), data);
        
        #endregion
        
    }
}
