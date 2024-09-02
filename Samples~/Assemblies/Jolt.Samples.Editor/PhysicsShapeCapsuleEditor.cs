using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsShapeCapsule)), CanEditMultipleObjects]
    public class PhysicsShapeCapsuleEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeCapsule;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawCapsuleShape(pos, rot, shape);
        }
    }
}
