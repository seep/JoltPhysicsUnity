using System;
using System.Linq;
using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;

namespace Jolt.Tests
{
    public class ExpectedStructSizeTests
    {
        [Test]
        public void TestStructSizes()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "Jolt");
            
            Assert.IsNotNull(assembly, "Unable to find Jolt assembly");
            
            foreach (var type in assembly.GetTypes())
            {
                foreach (var attr in GetTestAttributes<ExpectedStructSizeAttribute>(type))
                {
                    Assert.IsTrue(type.IsValueType, $"Expected {type} to be a value type");

                    var actualTypeSize = UnsafeUtility.SizeOf(type);
                    var expectTypeSize = UnsafeUtility.SizeOf(attr.Type);
                    
                    Assert.AreEqual(expectTypeSize, actualTypeSize, $"Expected {type} to be {expectTypeSize} bytes, actually {actualTypeSize} bytes");
                }
            }
        }
        
        private static T[] GetTestAttributes<T>(Type type) where T : Attribute
        {
            return type.GetCustomAttributes(typeof(ExpectedStructSizeAttribute), inherit: false) as T[];
        }
    }
}
