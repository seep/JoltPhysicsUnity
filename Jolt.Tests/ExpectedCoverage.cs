using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Jolt.Tests
{
    public class ExpectedCoverageTests
    {
        /// <summary>
        /// Method name prefixes to ignore in the coverage test for whatever reason. Ideally these wouldn't be
        /// generated at all but clangsharppinvokegenerator doesn't support excluding methods by name.
        /// </summary>
        private static HashSet<string> ignoreMethodNamePrefix = new()
        {
            "JPH_Matrix4x4",
            "JPH_RMatrix4x4",
            "JPH_Quat",
            "JPH_Vec3",
        };
        
        [Test]
        public void TestCoverage()
        {
            var methods = new HashSet<string>();
            
            foreach (var method in typeof(UnsafeBindings).GetMethods())
            {
                if (ignoreMethodNamePrefix.Any(s => method.Name.StartsWith(s)))
                {
                    continue;
                }
                
                methods.Add(Regex.Replace(method.Name, "[0-9]", "")); // combine numbered variants like Create, Create2, Create3
            }

            foreach (var method in typeof(Bindings).GetMethods())
            {
                methods.Remove(method.Name);
            }
            
            Assert.IsEmpty(string.Join("\n", methods));
        }
    }
}
