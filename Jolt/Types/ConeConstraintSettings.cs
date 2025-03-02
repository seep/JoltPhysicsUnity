using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_ConeConstraintSettings))]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConeConstraintSettings
    {
        public static ConeConstraintSettings Create()
        {
            var result = new ConeConstraintSettings();
            JPH_ConeConstraintSettings_Init(ref result);
            return result;
        }

        #region ConstraintSettings
        
        public NativeBool Enabled;

        public uint ConstraintPriority;

        public uint NumVelocityStepsOverride;

        public uint NumPositionStepsOverride;

        public float DrawConstraintSize;

        public ulong UserData;

        #endregion
        
        public ConstraintSpace Space;

        public rvec3 Point1;
        
        public float3 TwistAxis1;

        public rvec3 Point2;
        
        public float3 TwistAxis2;

        public float HalfConeAngle;
    }
}