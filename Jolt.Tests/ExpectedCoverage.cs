using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Jolt.Tests
{
    public class ExpectedCoverageTests
    {
        [Test]
        public void TestStructLayout()
        {
            Type safeBindingsType = typeof(Bindings);
            Type unsafeBindingsType = typeof(UnsafeBindings);

            var expect = new HashSet<string>();
            
            foreach (var unsafeBindingsMethod in unsafeBindingsType.GetMethods())
            {
                if (unsafeBindingsMethod.Name.StartsWith("JPH_"))
                {
                    expect.Add(unsafeBindingsMethod.Name);
                }
            }

            var actual = new HashSet<string>();

            foreach (var safeBindingsMethod in safeBindingsType.GetMethods())
            {
                actual.Add(safeBindingsMethod.Name);
            }

            var missingMethodNames = new StringBuilder();
            
            foreach (var expectMethodName in expect)
            {
                if (!actual.Contains(expectMethodName))
                {
                    missingMethodNames.AppendLine(expectMethodName);
                }
            }
            
            Assert.IsEmpty(missingMethodNames.ToString());
        }
    }
}
