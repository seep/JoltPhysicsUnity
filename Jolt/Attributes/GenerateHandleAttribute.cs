using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
    internal class GenerateHandleAttribute : Attribute
    {
        internal string NativePrefix;

        internal GenerateHandleAttribute(string prefix)
        {
            NativePrefix = prefix;
        }
    }
}
