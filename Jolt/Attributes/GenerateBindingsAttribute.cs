using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public class GenerateBindingsAttribute : Attribute
    {
        public string NativePrefix;

        public GenerateBindingsAttribute(string prefix)
        {
            NativePrefix = prefix;
        }
    }
}
