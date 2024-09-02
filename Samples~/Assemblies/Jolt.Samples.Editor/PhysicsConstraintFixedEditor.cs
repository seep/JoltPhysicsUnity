using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsConstraintFixed))]
    public class PhysicsConstraintFixedEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintFixed;
                
            if (constraint!.BodyA == null) return;
            if (constraint!.BodyB == null) return;

            var a = constraint.BodyA.transform.position;
            var b = constraint.BodyB.transform.position;

            PhysicsShapeHandles.DrawLine(a, b, 2f);
        }
    }
}