# Jolt.Generated

This project is responsible for generating the repetitive methods that forward our safe bindings.

The main assembly is roughly split into three layers: unsafe extern bindings (Jolt.UnsafeBindings), safe wrappers around
the unsafe bindings (Jolt.Bindings), and the public types that surface the function oriented bindings as object oriented
methods. Writing the safe bindings by hand is manageable, but the object methods are extremely repetitive, especially
around subclass-style methods (BoxShape should surface all the ConvexShape and Shape bindings, for example) because
we use structs to represent all of the native objects and cannot use inheritance.

This project _is not_ the actual source generator (see Jolt.SourceGenerator~) but merely applies the source generator
to the Jolt assembly while being excluded from Unity. Use `dotnet watch build` on this solution to watch the Jolt
assembly for changes and regenerate on demand. 
