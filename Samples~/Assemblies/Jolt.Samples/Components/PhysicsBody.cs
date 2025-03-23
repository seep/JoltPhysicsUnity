using System;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsBody : MonoBehaviour
    {
        public MotionType MotionType;

        [NonSerialized] public Body? NativeBody;

        [NonSerialized] public BodyID? NativeBodyID;
    }
}