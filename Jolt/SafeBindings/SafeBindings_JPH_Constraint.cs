using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_ConstraintSettings> JPH_Constraint_GetConstraintSettings(NativeHandle<JPH_Constraint> constraint)
        {
            return CreateOwnedHandle(constraint, Bindings.JPH_Constraint_GetConstraintSettings(constraint));
        }

        public static ConstraintType JPH_Constraint_GetType(NativeHandle<JPH_Constraint> constraint)
        {
            return Bindings.JPH_Constraint_GetType(constraint);
        }

        public static ConstraintSubType JPH_Constraint_GetSubType(NativeHandle<JPH_Constraint> constraint)
        {
            return Bindings.JPH_Constraint_GetSubType(constraint);
        }

        public static uint JPH_Constraint_GetConstraintPriority(NativeHandle<JPH_Constraint> constraint)
        {
            return Bindings.JPH_Constraint_GetConstraintPriority(constraint);
        }

        public static void JPH_Constraint_SetConstraintPriority(NativeHandle<JPH_Constraint> constraint, uint priority)
        {
            Bindings.JPH_Constraint_SetConstraintPriority(constraint, priority);
        }

        public static bool JPH_Constraint_GetEnabled(NativeHandle<JPH_Constraint> constraint)
        {
            return Bindings.JPH_Constraint_GetEnabled(constraint);
        }

        public static void JPH_Constraint_SetEnabled(NativeHandle<JPH_Constraint> constraint, bool enabled)
        {
            Bindings.JPH_Constraint_SetEnabled(constraint, enabled);
        }

        public static ulong JPH_Constraint_GetUserData(NativeHandle<JPH_Constraint> constraint)
        {
            return Bindings.JPH_Constraint_GetUserData(constraint);
        }

        public static void JPH_Constraint_SetUserData(NativeHandle<JPH_Constraint> constraint, ulong userData)
        {
            Bindings.JPH_Constraint_SetUserData(constraint, userData);
        }

        public static void JPH_Constraint_NotifyShapeChanged(NativeHandle<JPH_Constraint> constraint, BodyID bodyID, float3 deltaCOM)
        {
            Bindings.JPH_Constraint_NotifyShapeChanged(constraint, bodyID, &deltaCOM);
        }

        public static void JPH_Constraint_Destroy(NativeHandle<JPH_Constraint> constraint)
        {
            Bindings.JPH_Constraint_Destroy(constraint);

            constraint.Dispose();
        }
    }
}
