using System;

namespace FirstLib
{
    public class Subtraction : Arithematic
    {
        private double a;
        private double b;

        public Subtraction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double calculate()
        {
            return this.a - this.b;
        }
    }
}
