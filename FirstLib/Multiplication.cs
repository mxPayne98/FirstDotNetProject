using System;

namespace FirstLib
{
    public class Multiplication : Arithematic
    {
        private double a;
        private double b;

        public Multiplication(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double calculate()
        {
            return this.a * this.b;
        }
    }
}
