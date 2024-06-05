using System;

namespace Jolt
{
    internal class NativeTypeNameAttribute : Attribute
    {
        public string NativeTypeName;

        public NativeTypeNameAttribute(string s)
        {
            NativeTypeName = s;
        }
    }
}
