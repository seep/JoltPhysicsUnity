using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PhysicsSystem")]
    public partial struct PhysicsSystem
    {
        internal readonly NativeHandle<JPH_PhysicsSystem> Handle;

        /// <summary>
        /// The ObjectLayerPairFilter of the system.
        /// </summary>
        public ObjectLayerPairFilter ObjectLayerPairFilter;

        /// <summary>
        /// The BroadPhaseLayerInterface of the system.
        /// </summary>
        public BroadPhaseLayerInterface BroadPhaseLayerInterface;

        /// <summary>
        /// The ObjectVsBroadPhaseLayerFilter of the system.
        /// </summary>
        public ObjectVsBroadPhaseLayerFilter ObjectVsBroadPhaseLayerFilter;

        public PhysicsSystem(PhysicsSystemSettings settings)
        {
            Handle = JPH_PhysicsSystem_Create(settings);

            ObjectLayerPairFilter = settings.ObjectLayerPairFilter;
            BroadPhaseLayerInterface = settings.BroadPhaseLayerInterface;
            ObjectVsBroadPhaseLayerFilter = settings.ObjectVsBroadPhaseLayerFilter;
        }

        public void SetContactListener(ContactListener listener)
        {
            JPH_PhysicsSystem_SetContactListener(Handle, listener.Handle);
        }

        public void SetBodyActivationListener(BodyActivationListener listener)
        {
            JPH_PhysicsSystem_SetBodyActivationListener(Handle, listener.Handle);
        }

        /// <summary>
        /// Update the physics system. Returns true if there were no errors.
        /// </summary>
        /// <remarks>
        /// The out parameter will contain the error if any.
        /// </remarks>
        public bool Update(float deltaTime, int collisionSteps, JobSystem jobSystem, out PhysicsUpdateError error)
        {
            return (error = JPH_PhysicsSystem_Update(Handle, deltaTime, collisionSteps, jobSystem.Handle)) == PhysicsUpdateError.None;
        }
    }
}
