using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_FixedConstraintSettings))]
    public struct FixedConstraintSettings
    {
        public static FixedConstraintSettings Create()
        {
            var instance = new FixedConstraintSettings();
            JPH_FixedConstraintSettings_Init(ref instance);
            return instance;
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

        public NativeBool AutoDetectPoint;
        
        public rvec3 Point1;
        
        public float3 AxisX1;

        public float3 AxisY1;

        public rvec3 Point2;

        public float3 AxisX2;

        public float3 AxisY2;
    }
}
