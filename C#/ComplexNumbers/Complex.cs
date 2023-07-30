using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    public class Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public Complex(double re, double im = 0d) 
        {
            (Re,Im) = (re,im);
        }

        public Complex Conjugate() => (Re, -Im);

        public override string ToString()
        => "(" + Re + ", " + Im + "i" + ")";


        // OPERATORS

        // Complex to tuple
        public void Deconstruct(out double re, out double im)
        => (re,im) = (Re,Im);

        // Tuple to complex
        public static implicit operator Complex((double re, double im) t)
        => new Complex(t.re, t.im);

        // Real to complex
        public static implicit operator Complex(double re) => (re, 0);

        // Complex to real
        public static explicit operator double(Complex a)
        => (a.Im == 0) ? a.Re : throw new ArgumentException("Imaginary part is not zero");

        // Unary operators
        public static Complex operator +(Complex a) => a;
        public static Complex operator -(Complex a) => new Complex(-a.Re, -a.Im);

        // Binary operators
        public static Complex operator +(Complex a, Complex b)
        => (a.Re + b.Re, a.Im + b.Im);
        public static Complex operator -(Complex a, Complex b)
        => (a.Re - b.Re, a.Im - b.Im);

        public static Complex operator *(Complex a, double num)
        => (a.Re * num, a.Im * num);
        public static Complex operator /(Complex a, double num)
        => (num != 0) ? (a.Re / num, a.Im / num) : throw new DivideByZeroException();

        public static Complex operator *(Complex a, Complex b)
        => (a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);

        public static Complex operator /(Complex a, Complex b)
        {
            Complex conjugate = b.Conjugate();
            return (a * conjugate) / (b * conjugate).Re;
        }

        // Comparisons
        public static bool operator ==(Complex a, Complex b)
        => (a.Re == b.Re) && (a.Im == b.Im);

        public static bool operator !=(Complex a, Complex b)
        => !(a == b);

        public override bool Equals(object? obj)
        {
            return obj is Complex && Equals((Complex)obj);
        }

        public override int GetHashCode()
        {
            return (int)Re.GetHashCode();
        }
    }
}
