using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Jolt.Tests")]

namespace Jolt
{
    /// <summary>
    /// Indicates a struct should have the same size and layout as another struct.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    internal class ExpectedStructSizeAttribute : Attribute
    {
        public Type Type;
        
        public ExpectedStructSizeAttribute(Type type)
        {
            Type = type;
        }
    }
}
