using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsShapeSphere)), CanEditMultipleObjects]
    public class PhysicsShapeSphereEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeSphere;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawSphereShape(pos, rot, shape);
        }
    }
}
