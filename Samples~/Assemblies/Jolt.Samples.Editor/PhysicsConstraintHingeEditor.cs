using Unity.Mathematics;
using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsConstraintHinge))]
    public class PhysicsConstraintHingeEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintHinge;
                
            if (constraint!.BodyA == null) return;
            if (constraint!.BodyB == null) return;

            var point = constraint.HingePoint;

            PhysicsShapeHandles.DrawPoint(point, quaternion.identity);
        }
    }
}