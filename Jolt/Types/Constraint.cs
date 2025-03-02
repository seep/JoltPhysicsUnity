namespace Jolt
{
    [GenerateBindings("JPH_Constraint")]
    public partial struct Constraint
    {
        internal NativeHandle<JPH_Constraint> Handle;
        
        public static implicit operator Constraint(DistanceConstraint constraint)
        {
            return new Constraint { Handle = constraint.Handle.Reinterpret<JPH_Constraint>() };
        }

        public static implicit operator Constraint(FixedConstraint constraint)
        {
            return new Constraint { Handle = constraint.Handle.Reinterpret<JPH_Constraint>() };
        }
        
        public static implicit operator Constraint(PointConstraint constraint)
        {
            return new Constraint { Handle = constraint.Handle.Reinterpret<JPH_Constraint>() };
        }
        
        public static implicit operator Constraint(HingeConstraint constraint)
        {
            return new Constraint { Handle = constraint.Handle.Reinterpret<JPH_Constraint>() };
        }
        
        public static implicit operator Constraint(SliderConstraint constraint)
        {
            return new Constraint { Handle = constraint.Handle.Reinterpret<JPH_Constraint>() };
        }
    }
}
