using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Jolt.Tests")]

namespace Jolt
{
    internal static partial class Bindings
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        internal static void Initialize()
        {
            InitializeBodyActivationListeners();
            InitializeContactListeners();
        }
    }
}
