using Jolt;
using Jolt.Samples;
using Unity.Mathematics;
using UnityEngine;

public class PhysicsBodyOscillator : PhysicsSampleAddon
{
    private PhysicsBody managedBodyComponent;
    
    private float t;

    private void Awake()
    {
        managedBodyComponent = GetComponent<PhysicsBody>();
    }

    public override void PrePhysicsStep(PhysicsSystem system, ManagedPhysicsContext context)
    {
        // Oscillate the body on the X and Z rotation axes. Used to add some simple motion without pulling in motors.
        
        t += Time.fixedDeltaTime;

        const float scale = 0.2f;
        
        var x = math.cos(t);
        var y = 0f;
        var z = math.sin(t);

        var rot = quaternion.Euler(x * scale, y * scale, z * scale);
        
        var bodyID = context.ManagedToNative[managedBodyComponent].GetID();

        system.GetBodyInterface().SetRotation(bodyID, rot, Activation.Activate);
    }
}
