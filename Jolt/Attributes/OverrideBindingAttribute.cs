using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class OverrideBindingAttribute : Attribute
    {
        internal string BindingName;

        internal OverrideBindingAttribute(string name)
        {
            BindingName = name;
        }
    }
}
