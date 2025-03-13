using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;

namespace Jolt.Tests
{
    public class ExpectedStructSizeTests
    {
        [Test]
        public void TestStructLayout()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "Jolt");
            
            Assert.IsNotNull(assembly, "Unable to find Jolt assembly");
            
            foreach (var type in assembly.GetTypes())
            {
                foreach (var attr in GetCustomAttributes<ExpectedStructSizeAttribute>(type))
                {
                    TestStructLayout(type, attr.Type);
                }
            }
        }

        private static void TestStructLayout(Type actualType, Type expectType)
        {
            Assert.IsTrue(actualType.IsValueType, $"Expected {actualType} to be a value type");
            Assert.IsTrue(expectType.IsValueType, $"Expected {expectType} to be a value type");
            
            // TODO generate JPH types with explicit layout
            var isNotAutoLayout = actualType.IsLayoutSequential || actualType.IsExplicitLayout;
            Assert.IsTrue(isNotAutoLayout, $"Expected {actualType} to have sequential or explicit layout");
            
            var actualTypeSize = UnsafeUtility.SizeOf(actualType);
            var expectTypeSize = UnsafeUtility.SizeOf(expectType);
                    
            Assert.AreEqual(expectTypeSize, actualTypeSize, $"Expected {actualType} to be {expectTypeSize} bytes, actually {actualTypeSize} bytes");

            var actualFields = actualType.GetFields(BindingFlags.Public | BindingFlags.NonPublic);
            var expectFields = expectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic);
                    
            Assert.AreEqual(expectFields.Length, actualFields.Length, $"Expected {actualType} to have {expectFields.Length} fields, actually {actualFields.Length} fields");

            for (var i = 0; i < actualFields.Length; i++)
            {
                var actualField = actualFields[i];
                var expectField = expectFields[i];

                var actualFieldSize = UnsafeUtility.SizeOf(actualField.FieldType);
                var expectFieldSize = UnsafeUtility.SizeOf(expectField.FieldType);
                
                Assert.AreEqual(actualFieldSize, expectFieldSize, $"Expected {actualType}.{actualField.Name} to be {expectFieldSize} bytes, actually {actualFieldSize} bytes");
            }
        }
        
        private static T[] GetCustomAttributes<T>(Type type) where T : Attribute
        {
            return type.GetCustomAttributes(typeof(ExpectedStructSizeAttribute), inherit: false) as T[];
        }
    }
}
