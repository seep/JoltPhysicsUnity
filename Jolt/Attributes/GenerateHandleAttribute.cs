using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
    internal class GenerateHandleAttribute : Attribute
    {
        public string NativePrefix;

        public GenerateHandleAttribute(string prefix)
        {
            NativePrefix = prefix;
        }
    }
}
