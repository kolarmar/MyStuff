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


        // OPERATORS

        // Complex to tuple
        public void Deconstruct(out double re, out double im)
        => (re,im) = (Re,Im);

        // Tuple to complex
        public static implicit operator Complex((double re, double im) t)
        => new Complex(t.re, t.im);

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




    }
}
