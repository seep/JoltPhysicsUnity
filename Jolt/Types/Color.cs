using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Jolt
{
    [StructLayout(LayoutKind.Explicit), ExpectedStructSize(typeof(uint))]
    public struct Color : IEquatable<Color>
    {
        [FieldOffset(0)] public uint Value;

        [FieldOffset(0)] public byte R;
        [FieldOffset(1)] public byte G;
        [FieldOffset(2)] public byte B;
        [FieldOffset(3)] public byte A;

        public Color(uint value)
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
            
            Value = value;
        }
        
        public Color(byte r, byte g, byte b, byte a)
        {
            Value = 0;
            
            R = r;
            G = g;
            B = b;
            A = a;
        }
        
        public static explicit operator Color32(Color color)
        {
            return new Color32(color.R, color.G, color.B, color.A);
        }
        
        public static explicit operator Color(Color32 color)
        {
            return new Color(color.r, color.g, color.b, color.a);
        }
        
        #region IEquatable
        
        public bool Equals(Color other) => Value == other.Value;

        public override bool Equals(object obj) => obj is Color other && Equals(other);

        public override int GetHashCode() => (int)Value;

        public static bool operator ==(Color left, Color right) => left.Equals(right);

        public static bool operator !=(Color left, Color right) => !left.Equals(right);

        #endregion
    }
}
