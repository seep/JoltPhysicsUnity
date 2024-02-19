using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsShapeBox)), CanEditMultipleObjects]
    public class PhysicsShapeBoxEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeBox;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawBoxShape(pos, rot, shape);
        }
    }
}
