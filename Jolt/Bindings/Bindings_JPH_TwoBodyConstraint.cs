using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_Body> JPH_TwoBodyConstraint_GetBody1(NativeHandle<JPH_TwoBodyConstraint> constraint)
        {
            return CreateHandle(UnsafeBindings.JPH_TwoBodyConstraint_GetBody1(constraint));
        }

        public static NativeHandle<JPH_Body> JPH_TwoBodyConstraint_GetBody2(NativeHandle<JPH_TwoBodyConstraint> constraint) 
        {
            return CreateHandle(UnsafeBindings.JPH_TwoBodyConstraint_GetBody2(constraint));
        }

        public static float4x4 JPH_TwoBodyConstraint_GetConstraintToBody1Matrix(NativeHandle<JPH_TwoBodyConstraint> constraint)
        {
            float4x4 result;
            UnsafeBindings.JPH_TwoBodyConstraint_GetConstraintToBody1Matrix(constraint, &result);
            return result;
        }

        public static float4x4 JPH_TwoBodyConstraint_GetConstraintToBody2Matrix(NativeHandle<JPH_TwoBodyConstraint> constraint) 
        {
            float4x4 result;
            UnsafeBindings.JPH_TwoBodyConstraint_GetConstraintToBody2Matrix(constraint, &result);
            return result;
        }
    }
}