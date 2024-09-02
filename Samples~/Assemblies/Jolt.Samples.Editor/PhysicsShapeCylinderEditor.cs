using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsShapeCylinder)), CanEditMultipleObjects]
    public class PhysicsShapeCylinderEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeCylinder;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawPhysicsCylinder(pos, rot, shape);
        }
    }
}
