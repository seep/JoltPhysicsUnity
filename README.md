# JoltPhysicsUnity 

This package provides __work-in-progress__ bindings for [Jolt Physics](https://github.com/jrouwe/JoltPhysics)
specifically for Unity. It uses the Unity.Mathematics package for all numerics and Unity.Collections
package for unmanaged collections.

The C# API is almost entirely implemented on unmanaged structs, making it suitable for use from
Unity Jobs and Burst compiled code.

### Acknowledgements

This package relies on the `joltc` bindings written by [amerkoleci](https://github.com/amerkoleci)
for [JoltPhysicsSharp](https://github.com/amerkoleci/JoltPhysicsSharp). Please consider sponsoring
them.

The De Chalon mesh used in the samples is taken from [ThreeDScans](https://github.com/keijiro/ThreeDScans/tree/d7c6be2a997fb38ec850d7a0f03fa627bd736216).
