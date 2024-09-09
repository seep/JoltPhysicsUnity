namespace Jolt
{
    [GenerateHandle("JPH_Constraint"), GenerateBindings("JPH_Constraint")]
    public readonly partial struct Constraint
    {
        public static implicit operator Constraint(DistanceConstraint constraint)
        {
            return new Constraint(constraint.Handle.Reinterpret<JPH_Constraint>());
        }

        public static implicit operator Constraint(FixedConstraint constraint)
        {
            return new Constraint(constraint.Handle.Reinterpret<JPH_Constraint>());
        }
        
        public static implicit operator Constraint(PointConstraint constraint)
        {
            return new Constraint(constraint.Handle.Reinterpret<JPH_Constraint>());
        }
        
        public static implicit operator Constraint(HingeConstraint constraint)
        {
            return new Constraint(constraint.Handle.Reinterpret<JPH_Constraint>());
        }
        
        public static implicit operator Constraint(SliderConstraint constraint)
        {
            return new Constraint(constraint.Handle.Reinterpret<JPH_Constraint>());
        }
    }
}
