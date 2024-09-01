using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Jolt.Samples
{
    /// <summary>
    /// Helper structure to associate native bodies with game objects, so we can efficiently apply the physics state.
    /// </summary>
    public class ManagedPhysicsContext
    {
        /// <summary>
        /// The map from Unity PhysicsBody components to native Body instances. 
        /// </summary>
        public IReadOnlyDictionary<PhysicsBody, Body> ManagedToNative => managedToNative;
        
        /// <summary>
        /// The map from native Body instances to Unity PhysicsBody components.
        /// </summary>
        public IReadOnlyDictionary<Body, PhysicsBody> NativeToManaged => nativeToManaged;

        /// <summary>
        /// The list of native body ID and PhysicsBody components tuples (faster than enumerating the dicts).
        /// </summary>
        public IReadOnlyList<(BodyID, PhysicsBody)> Bodies => bodies;

        private Dictionary<PhysicsBody, Body> managedToNative = new ();
        private Dictionary<Body, PhysicsBody> nativeToManaged = new ();
        
        private List<(BodyID, PhysicsBody)> bodies = new();
        
        public void Add(Body body, PhysicsBody comp)
        {
            Assert.IsFalse(ManagedToNative.ContainsKey(comp));
            Assert.IsFalse(NativeToManaged.ContainsKey(body));
            
            managedToNative.Add(comp, body);
            nativeToManaged.Add(body, comp);
            
            bodies.Add((body.GetID(), comp));
        }
    }
}