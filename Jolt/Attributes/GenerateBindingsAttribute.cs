using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
    internal class GenerateBindingsAttribute : Attribute
    {
        internal string NativePrefix;

        internal GenerateBindingsAttribute(string prefix)
        {
            NativePrefix = prefix;
        }
    }
}
