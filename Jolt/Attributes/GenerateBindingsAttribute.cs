using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct)]
    internal class GenerateBindingsAttribute : Attribute
    {
        internal string[] NativeTypes;

        internal GenerateBindingsAttribute(params string[] types)
        {
            NativeTypes = types;
        }
    }
}
