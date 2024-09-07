using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct)]
    internal class GenerateHandleAttribute : Attribute
    {
        internal string NativeType;

        internal GenerateHandleAttribute(string type)
        {
            NativeType = type;
        }
    }
}
