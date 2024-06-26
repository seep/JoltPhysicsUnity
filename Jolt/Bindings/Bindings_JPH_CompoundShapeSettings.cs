﻿using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_CompoundShapeSettings_AddShape<T, U>(NativeHandle<T> handle, float3 position, quaternion rotation, NativeHandle<U> settings, uint userData) where T : unmanaged, INativeCompoundShapeSettings where U : unmanaged, INativeShapeSettings
        {
            UnsafeBindings.JPH_CompoundShapeSettings_AddShape(handle.Reinterpret<JPH_CompoundShapeSettings>(), &position, &rotation, settings.Reinterpret<JPH_ShapeSettings>(), userData);
        }

        public static void JPH_CompoundShapeSettings_AddShape2<T, U>(NativeHandle<T> settings, float3 position, quaternion rotation, NativeHandle<U> shape, uint userData) where T : unmanaged, INativeCompoundShapeSettings where U : unmanaged, INativeShape
        {
            UnsafeBindings.JPH_CompoundShapeSettings_AddShape2(settings.Reinterpret<JPH_CompoundShapeSettings>(), &position, &rotation, shape.Reinterpret<JPH_Shape>(), userData);
        }

        public static NativeHandle<JPH_StaticCompoundShapeSettings> JPH_StaticCompoundShapeSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_StaticCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShapeSettings> JPH_MutableCompoundShapeSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_MutableCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShape> JPH_MutableCompoundShape_Create(NativeHandle<JPH_MutableCompoundShapeSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_MutableCompoundShape_Create(settings));
        }
    }
}
