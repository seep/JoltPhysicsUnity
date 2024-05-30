using System;

namespace Jolt
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class OverrideBindingAttribute : Attribute
    {
        public string BindingName;

        public OverrideBindingAttribute(string name)
        {
            BindingName = name;
        }
    }
}
