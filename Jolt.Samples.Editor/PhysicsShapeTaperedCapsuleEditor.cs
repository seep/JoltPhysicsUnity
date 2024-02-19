using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsShapeTaperedCapsule)), CanEditMultipleObjects]
    public class PhysicsShapeTaperedCapsuleEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeTaperedCapsule;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawTaperedCapsuleShape(pos, rot, shape);
        }
    }
}
