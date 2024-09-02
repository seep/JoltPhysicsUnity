using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsConstraintDistance))]
    public class PhysicsConstraintDistanceEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintDistance;
            
            if (constraint!.BodyA == null) return;
            if (constraint!.BodyB == null) return;
                
            var a = constraint.BodyA.transform.position;
            var b = constraint.BodyB.transform.position;

            PhysicsShapeHandles.DrawLine(a, b, 2f);
        }
    }
}