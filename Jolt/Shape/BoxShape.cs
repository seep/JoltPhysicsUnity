﻿using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BoxShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_BoxShape")]
    public readonly partial struct BoxShape
    {
        internal readonly NativeHandle<JPH_BoxShape> Handle;

        internal BoxShape(NativeHandle<JPH_BoxShape> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_BoxShape_Create")]
        public static BoxShape Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShape(JPH_BoxShape_Create(halfExtent, convexRadius));
        }

        [OverrideBinding("JPH_Shape_GetVolume"), OverrideBinding("JPH_BoxShape_GetVolume")]
        public float GetVolume()
        {
            return JPH_BoxShape_GetVolume(Handle); // defined in both JPH_Shape and JPH_BoxShape, explicitly use JPH_BoxShape impl
        }
    }
}
