# JoltPhysicsUnity

This package provides __work-in-progress__ bindings for [Jolt Physics v5.3.0](https://github.com/jrouwe/JoltPhysics)
specifically for Unity. It uses the Unity.Mathematics package for all numerics and Unity.Collections
package for unmanaged collections.

The C# API is almost entirely implemented on unmanaged structs, making it suitable for use from
Unity Jobs and Burst compiled code.

### Installation

The package is not currently published on any registries. You can [add it as a git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
or [embed it directly in your project](https://docs.unity3d.com/Manual/upm-embed.html).

### Acknowledgements

This package relies on the `joltc` bindings written by [amerkoleci](https://github.com/amerkoleci)
for [JoltPhysicsSharp](https://github.com/amerkoleci/JoltPhysicsSharp). Please consider sponsoring
them.

The De Chalon mesh used in the samples is taken from [ThreeDScans](https://github.com/keijiro/ThreeDScans/tree/d7c6be2a997fb38ec850d7a0f03fa627bd736216).