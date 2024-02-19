using System;

namespace Jolt.Native
{
    public class NativeTypeNameAttribute : Attribute
    {
        public string NativeTypeName;

        public NativeTypeNameAttribute(string s)
        {
            NativeTypeName = s;
        }
    }
}
